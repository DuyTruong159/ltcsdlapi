using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class BLL : BLLInterface
    {

        DALInterface dal;

        public BLL()
        {
            dal = new DAL.DAL();
        }

        public bool addUser(UserModel model)
        {
            return dal.addUser(model);
        }

        public List<CourseModel> getCourse()
        {
            return dal.getCourse();
        }

        public void getCourseDelete(int id)
        {
            dal.getCourseDelete(id);
        }

        public CourseModel GetCourseInfo(int id)
        {
            return dal.getCourseInfo(id);
        }

        public List<LessonModel> GetLesson(int id)
        {
            return dal.getLesson(id);
        }

        public LessonModel GetLessonInfo(int id)
        {
            return dal.GetLessonInfo(id);
        }

        public List<LessonModel> GetLessons()
        {
            return dal.GetLessons();
        }

        public List<LessonModel> GetLessonsCount()
        {
            return dal.GetLessonsCount();
        }

        public void GetLessonsDelete(int id)
        {
            dal.GetLessonsDelete(id);
        }

        public List<UnitModel> GetUnit()
        {
            return dal.GetUnit();
        }

        public List<UnitInfoModel> GetUnitInfo()
        {
            return dal.GetUnitInfo();
        }

        public void GetUnitInfoDelete(int id)
        {
            dal.GetUnitInfoDelete(id);
        }

        public List<UnitInfoModel> GetUnitInfos(int id)
        {
            return dal.GetUnitInfos(id);
        }

        public List<UnitInfoModel> GetUnitInfosExcept(int unitId, int exceptId)
        {
            return dal.GetUnitInfosExcept(unitId, exceptId);
        }

        public UnitInfoModel GetUnitInfo_Info(int id)
        {
            return dal.GetUnitInfo_Info(id);
        }

        public List<UnitModel> GetUnits(int id)
        {
            return dal.GetUnits(id);
        }

        public void GetUnitsDelete(int id)
        {
            dal.GetUnitsDelete(id);
        }

        public UnitModel GetUnitsInfo(int id)
        {
            return dal.GetUnitsInfo(id);
        }

        public UserModel GetUser(UserModel model)
        {
            return dal.GetUser(model);
        }

        public List<UserModel> GetUsers()
        {
            return dal.GetUsers();
        }

        public void GetUsersDelete(int id)
        {
            dal.GetUsersDelete(id);
        }

        public UserModel GetUsersInfo(int id)
        {
            return dal.GetUsersInfo(id);
        }
    }
}
