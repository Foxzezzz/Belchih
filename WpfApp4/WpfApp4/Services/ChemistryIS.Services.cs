
using Npgsql;
using System.Collections.Generic;
using System.Data;
using ChemistryIS.Models;
using ChemistryIS.Models.ChemistryIS.Models;

namespace ChemistryIS.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123";

        public List<Topic> GetAllTopics()
        {
            var topics = new List<Topic>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                // Получаем темы
                using (var cmd = new NpgsqlCommand("SELECT id, title, description FROM topics ORDER BY sort_order", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        topics.Add(new Topic
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.IsDBNull(2) ? "" : reader.GetString(2)
                        });
                    }
                }

                foreach (var topic in topics)
                {
                    topic.Contents = GetContentForTopic(topic.Id, conn);
                }
            }
            return topics;
        }

        private List<TopicContent> GetContentForTopic(int topicId, NpgsqlConnection conn)
        {
            var contents = new List<TopicContent>();
            using (var cmd = new NpgsqlCommand("SELECT section_title, body_text FROM topic_content WHERE topic_id = @tid", conn))
            {
                cmd.Parameters.AddWithValue("tid", topicId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contents.Add(new TopicContent
                        {
                            SectionTitle = reader.GetString(0),
                            BodyText = reader.GetString(1)
                        });
                    }
                }
            }
            return contents;
        }

        public ChemicalElement FindElement(string query)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, atomic_number, symbol, name_ru, atomic_mass, category, electron_config " +
                             "FROM elements " +
                             "WHERE atomic_number::text = @q OR LOWER(symbol) = LOWER(@q) OR LOWER(name_ru) = LOWER(@q) " +
                             "LIMIT 1";

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("q", query);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ChemicalElement
                            {
                                Id = reader.GetInt32(0),
                                AtomicNumber = reader.GetInt32(1),
                                Symbol = reader.GetString(2),
                                NameRu = reader.GetString(3),
                                AtomicMass = (double)reader.GetDecimal(4),
                                Category = reader.IsDBNull(5) ? "Нет данных" : reader.GetString(5),
                                ElectronConfig = reader.IsDBNull(6) ? "Нет данных" : reader.GetString(6)
                            };
                        }
                    }
                }
            }
            return new ChemicalElement { IsNotFound = true, NameRu = query };
        }
    }
}