using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace CyberSecurityBot
{
    public class TaskRepository
    {
        private string connectionString = "Data Source=CyberBotDB.sqlite;Version=3;";

        public TaskRepository()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string table = @"
                CREATE TABLE IF NOT EXISTS Tasks (
                    TaskId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT,
                    Description TEXT,
                    ReminderDate TEXT,
                    IsCompleted INTEGER
                );";

                SQLiteCommand cmd = new SQLiteCommand(table, conn);
                cmd.ExecuteNonQuery();
            }
        }

        // ADD TASK
        public void AddTask(string title, string description, string reminder)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Tasks (Title, Description, ReminderDate, IsCompleted) VALUES (@t,@d,@r,0)";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);

                cmd.Parameters.AddWithValue("@t", title);
                cmd.Parameters.AddWithValue("@d", description);
                cmd.Parameters.AddWithValue("@r", reminder);

                cmd.ExecuteNonQuery();
            }
        }

        // GET TASKS
        public List<string> GetTasks()
        {
            List<string> tasks = new List<string>();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Tasks";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);

                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tasks.Add(
                        $"[{reader["TaskId"]}] {reader["Title"]} - {reader["Description"]} | Reminder: {reader["ReminderDate"]} | Done: {reader["IsCompleted"]}"
                    );
                }
            }

            return tasks;
        }

        // DELETE TASK
        public void DeleteTask(int id)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Tasks WHERE TaskId=@id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // COMPLETE TASK
        public void MarkCompleted(int id)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Tasks SET IsCompleted=1 WHERE TaskId=@id";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}