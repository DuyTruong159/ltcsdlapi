using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DAL : DALInterface
    {
        MySqlConnection conn;

        public DAL()
        {
            string strconn = "server = 127.0.0.1; uid = root; pwd = phamduytruong; database = englishtest";
            conn = new MySqlConnection();
            conn.ConnectionString = strconn;
        }

        public bool addUser(UserModel model)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.addUser('{0}', '{1}', '{2}', '{3}')", model.fullname, model.username, model.password, model.email);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }

            return false;
        }

        public List<CourseModel> getCourse()
        {
            var Result = new List<CourseModel>();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getCourse()");
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.Add(new CourseModel()
                    {
                        id = int.Parse(dr["id"].ToString()),
                        name = dr["name"].ToString(),
                        image = dr["image"].ToString(),
                        description = dr["description"].ToString()
                    });
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;

        }

        public void getCourseDelete(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getCourseDelete({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public CourseModel getCourseInfo(int id)
        {
            var Result = new CourseModel();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getCourseInfo({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.id = int.Parse(dr["id"].ToString());
                    Result.name = dr["name"].ToString();
                    Result.image = dr["image"].ToString();
                    Result.description = dr["description"].ToString();
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public void postCourseInsert(CourseModel model)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.postCourseInsert('{0}', '{1}', '{2}')", model.name, model.image, model.description);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public List<LessonModel> getLesson(int id)
        {
            var Result = new List<LessonModel>();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getLessons({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.Add(new LessonModel()
                    {
                        id = int.Parse(dr["id"].ToString()),
                        name = dr["name"].ToString(),
                        image = dr["image"].ToString(),
                        description = dr["description"].ToString(),
                        courseId = int.Parse(dr["course_id"].ToString()),
                        money = int.Parse(dr["money"].ToString())
                    });
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public LessonModel GetLessonInfo(int id)
        {
            var Result = new LessonModel();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getLessonsInfo({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.id = int.Parse(dr["id"].ToString());
                    Result.name = dr["name"].ToString();
                    Result.image = dr["image"].ToString();
                    Result.description = dr["description"].ToString();
                    Result.courseId = int.Parse(dr["course_id"].ToString());
                    Result.money = int.Parse(dr["money"].ToString());
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public List<LessonModel> GetLessons()
        {
            var Result = new List<LessonModel>();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getLesson()");
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.Add(new LessonModel()
                    {
                        id = int.Parse(dr["id"].ToString()),
                        name = dr["name"].ToString(),
                        image = dr["image"].ToString(),
                        description = dr["description"].ToString(),
                        courseId = int.Parse(dr["course_id"].ToString()),
                        money = int.Parse(dr["money"].ToString())
                    });
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public List<LessonModel> GetLessonsCount()
        {
            var Result = new List<LessonModel>();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getLessonsCount()");
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.Add(new LessonModel()
                    {
                        id = int.Parse(dr["id"].ToString()),
                        name = dr["name"].ToString(),
                        image = dr["image"].ToString(),
                        description = dr["description"].ToString(),
                        courseId = int.Parse(dr["course_id"].ToString()),
                        money = int.Parse(dr["money"].ToString())
                    });
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public void GetLessonsDelete(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getLessonsDelete({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public List<UnitModel> GetUnit()
        {
            var Result = new List<UnitModel>();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getUnits()");
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.Add(new UnitModel()
                    {
                        id = int.Parse(dr["id"].ToString()),
                        name = dr["name"].ToString(),
                        trans_name = dr["trans_name"].ToString(),
                        lessonId = int.Parse(dr["lessonId"].ToString())
                    });
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public List<UnitInfoModel> GetUnitInfo()
        {
            var Result = new List<UnitInfoModel>();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getUnitInfo()");
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.Add(new UnitInfoModel()
                    {
                        id = int.Parse(dr["id"].ToString()),
                        name = dr["name"].ToString(),
                        trans_name = dr["trans_name"].ToString(),
                        description = dr["description"].ToString(),
                        video = dr["video"].ToString(),
                        css = dr["css"].ToString(),
                        unitId = int.Parse(dr["unitId"].ToString()),
                        lessonId = int.Parse(dr["lessonId"].ToString())
                    });
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public void GetUnitInfoDelete(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getUnitInfoDelete({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public List<UnitInfoModel> GetUnitInfos(int id)
        {
            var Result = new List<UnitInfoModel>();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getUnit_Info({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.Add(new UnitInfoModel()
                    {
                        id = int.Parse(dr["id"].ToString()),
                        name = dr["name"].ToString(),
                        trans_name = dr["trans_name"].ToString(),
                        description = dr["description"].ToString(),
                        video = dr["video"].ToString(),
                        css = dr["css"].ToString(),
                        unitId = int.Parse(dr["unitId"].ToString()),
                        lessonId = int.Parse(dr["lessonId"].ToString())
                    });
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public List<UnitInfoModel> GetUnitInfosExcept(int unitId, int exceptId)
        {
            var Result = new List<UnitInfoModel>();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getUnitInfoExcept({0}, {1})", unitId, exceptId);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.Add(new UnitInfoModel()
                    {
                        id = int.Parse(dr["id"].ToString()),
                        name = dr["name"].ToString(),
                        trans_name = dr["trans_name"].ToString(),
                        description = dr["description"].ToString(),
                        video = dr["video"].ToString(),
                        css = dr["css"].ToString(),
                        unitId = int.Parse(dr["unitId"].ToString()),
                        lessonId = int.Parse(dr["lessonId"].ToString())
                    });
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public UnitInfoModel GetUnitInfo_Info(int id)
        {
            var Result = new UnitInfoModel();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getUnitInfo_Info({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.id = int.Parse(dr["id"].ToString());
                    Result.name = dr["name"].ToString();
                    Result.trans_name = dr["trans_name"].ToString();
                    Result.description = dr["description"].ToString();
                    Result.video = dr["video"].ToString();
                    Result.css = dr["css"].ToString();
                    Result.unitId = int.Parse(dr["unitId"].ToString());
                    Result.lessonId = int.Parse(dr["lessonId"].ToString());
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public List<UnitModel> GetUnits(int id)
        {
            var Result = new List<UnitModel>();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getUnit({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.Add(new UnitModel()
                    {
                        id = int.Parse(dr["id"].ToString()),
                        name = dr["name"].ToString(),
                        trans_name = dr["trans_name"].ToString(),
                        lessonId = int.Parse(dr["lessonId"].ToString())
                    });
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public void GetUnitsDelete(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getUnitsDelete({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public UnitModel GetUnitsInfo(int id)
        {
            var Result = new UnitModel();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getUnitsInfo({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.id = int.Parse(dr["id"].ToString());
                    Result.name = dr["name"].ToString();
                    Result.trans_name = dr["trans_name"].ToString();
                    Result.lessonId = int.Parse(dr["lessonId"].ToString());
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public UserModel GetUser(UserModel model)
        {
            var Result = new UserModel();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.sp_login('{0}', '{1}')", model.username, model.password);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.id = int.Parse(dr["id"].ToString());
                    Result.fullname = dr["fullname"].ToString();
                    Result.username = dr["username"].ToString();
                    Result.password = dr["password"].ToString();
                    Result.email = dr["email"].ToString();
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public List<UserModel> GetUsers()
        {
            var Result = new List<UserModel>();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getUsers()");
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.Add(new UserModel()
                    {
                        id = int.Parse(dr["id"].ToString()),
                        username = dr["username"].ToString(),
                        fullname = dr["fullname"].ToString(),
                        password = dr["password"].ToString(),
                        email = dr["email"].ToString()
                    });
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public void GetUsersDelete(int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getUsersDelete({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public UserModel GetUsersInfo(int id)
        {
            var Result = new UserModel();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.getUsersInfo({0})", id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.id = int.Parse(dr["id"].ToString());
                    Result.fullname = dr["fullname"].ToString();
                    Result.username = dr["username"].ToString();
                    Result.password = dr["password"].ToString();
                    Result.email = dr["email"].ToString();
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }

        public void PostUserUpdate(int id, UserModel model)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.postUpdateUser({0}, '{1}', '{2}', '{3}', '{4}')", id, model.fullname, model.username, model.password, model.email);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public void PostCourseUpdate(int id, CourseModel model)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.postUpdateCourse({0}, '{1}', '{2}', '{3}')", id, model.name, model.image, model.description);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public void postLessonInsert(LessonModel model)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.postLessonsInsert('{0}', '{1}', '{2}', {3}, {4})", model.name, model.image, model.description, model.courseId, model.money);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public void postLessonUpdate(int id, LessonModel model)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.postLessonsUpdate({0}, '{1}', '{2}', '{3}', {4}, {5})", id, model.name, model.image, model.description, model.courseId, model.money);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public void postUnitInsert(UnitModel model)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.postUnitInsert('{0}', '{1}', {2})", model.name, model.trans_name, model.lessonId);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public void postUnitUpdate(int id, UnitModel model)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.postUnitUpdate({0}, '{1}', '{2}', {3})", id, model.name, model.trans_name, model.lessonId);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public void postUnitInfoInsert(UnitInfoModel model)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.postUnitInfoInsert('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6})", model.name, model.trans_name, model.description, model.video, model.css, model.unitId, model.lessonId);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public void postUnitInfoUpdate(int id, UnitInfoModel model)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.postUnitInfoUpdate({0}, '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7})", id, model.name, model.trans_name, model.description, model.video, model.css, model.unitId, model.lessonId);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                conn.Close();
            }
        }

        public UserModel Login(UserModel model)
        {
            var Result = new UserModel();

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("CALL englishtest.sp_login('{0}', '{1}')", model.username, model.password);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sb.ToString();

                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Result.id = int.Parse(dr["id"].ToString());
                    Result.fullname = dr["fullname"].ToString();
                    Result.username = dr["username"].ToString();
                    Result.password = dr["password"].ToString();
                    Result.email = dr["email"].ToString();
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                Result = null;
                conn.Close();
            }

            return Result;
        }
    }
}
