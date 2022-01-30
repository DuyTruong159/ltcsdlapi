using System;
using System.Collections.Generic;
using DTO;

namespace DAL
{
    public interface DALInterface
    {
        UserModel GetUser(UserModel model);
        bool addUser(UserModel model);
        List<UserModel> GetUsers();
        UserModel GetUsersInfo(int id);
        void GetUsersDelete(int id);
        void PostUserUpdate(int id, UserModel model);

        List<CourseModel> getCourse();
        void getCourseDelete(int id);
        CourseModel getCourseInfo(int id);
        void postCourseInsert(CourseModel model);
        void PostCourseUpdate(int id, CourseModel model);

        List<LessonModel> getLesson(int id);
        List<LessonModel> GetLessons();
        void GetLessonsDelete(int id);
        List<LessonModel> GetLessonsCount();
        LessonModel GetLessonInfo(int id);
        void postLessonInsert(LessonModel model);
        void postLessonUpdate(int id, LessonModel model);

        List<UnitModel> GetUnits(int id);
        List<UnitModel> GetUnit();
        UnitModel GetUnitsInfo(int id);
        void GetUnitsDelete(int id);
        void postUnitInsert(UnitModel model);
        void postUnitUpdate(int id, UnitModel model);

        List<UnitInfoModel> GetUnitInfos(int id);
        List<UnitInfoModel> GetUnitInfo();
        List<UnitInfoModel> GetUnitInfosExcept(int unitId, int exceptId);
        UnitInfoModel GetUnitInfo_Info(int id);
        void GetUnitInfoDelete(int id);
        void postUnitInfoInsert(UnitInfoModel model);
        void postUnitInfoUpdate(int id, UnitInfoModel model);
    }
}
