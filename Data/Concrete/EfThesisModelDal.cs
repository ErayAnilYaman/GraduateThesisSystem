
namespace Data.Concrete

{
    #region usings
using Data.Abstract;
    using Data.Concrete.Base;
    using Data.Db;
    using Data.Models.DTOs;
    #endregion
    
    public class EfThesisModelDal : EfEntityRepositoryBase<ThesisModel, ThesesContext>, IThesisModelDal
    {
        public IEnumerable<ThesisModel> GetThesisModel()
        {
            using (var db = new ThesesContext())
            {
                var result = (from t in db.THESES
                              join i in db.INSTITUTES
                              on t.INSTITUTEID equals i.INSTITUTEID
                              join u in db.UNIVERSITIES
                              on t.UNIVERSITYID equals u.ID
                              join s in db.SUPERVISORS
                              on t.SUPERVISORID equals s.SUPERVISORID
                              join a in db.AUTHORS
                              on t.AUTHORID equals a.AUTHORID
                              select new ThesisModel
                              {
                                  ABSTRACT = t.ABSTRACT,
                                  INSTITUTENAME = i.INSTITUTENAME,
                                  NUMBER = t.NUMBER,
                                  SUPERVISORFIRSTNAME = s.FIRSTNAME,
                                  SUPERVISORLASTNAME = s.LASTNAME,
                                  THESISYEAR = t.THESISYEAR,
                                  TITLE = t.TITLE,
                                  TYPE = t.TYPE,
                                  UNIVERSITYNAME = u.UNIVERSITYNAME,
                                  AUTHORNAME = a.AUTHORNAME

                              });
                return result;
            }
        }
    }
}
