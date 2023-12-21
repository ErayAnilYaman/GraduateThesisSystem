
namespace Data.Concrete

{
    #region usings
    using Data.Abstract;
    using Data.Concrete.Base;
    using Data.Db;
    using Data.Models;
    using Data.Models.DTOs;
    using System.Collections.Generic;
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
                              on t.UNIVERSITYID equals u.UNIVERSITYID
                              join s in db.SUPERVISORS
                              on t.SUPERVISORID equals s.SUPERVISORID
                              join a in db.AUTHORS
                              on t.AUTHORID equals a.AUTHORID
                              select new ThesisModel
                              {
                                  INSTITUTEID = i.INSTITUTEID,
                                  NUMBER = t.NUMBER,
                                  SUPERVISORFIRSTNAME = s.FIRSTNAME,
                                  SUPERVISORLASTNAME = s.LASTNAME,
                                  THESISYEAR = t.THESISYEAR,
                                  TITLE = t.TITLE,
                                  TYPE = t.TYPE,
                                  UNIVERSITYID = u.UNIVERSITYID,
                                  AUTHORNAME = a.AUTHORNAME

                              });
                return result;
            }

        }
        public IEnumerable<ThesisModel> GetFilter(ThesisModel model)
        {
            using (ThesesContext db = new ThesesContext())
            {
                var result = db.THESES.Where(T =>
                T.TITLE.Contains(model.TITLE)
                && T.LANGUAGE.Contains(model.LANGUAGE)
                && T.AUTHOR.AUTHORNAME.Contains(model.AUTHORNAME)
                && T.AUTHOR.LASTNAME.Contains(model.AUTHORLASTNAME)
                && T.SUPERVISOR.FIRSTNAME.Contains(model.SUPERVISORFIRSTNAME)
                && T.SUPERVISOR.LASTNAME.Contains(model.SUPERVISORLASTNAME)
                && T.THESISYEAR.Contains(model.THESISYEAR)
                && T.TYPE.Contains(model.TYPE)
                && T.INSTITUTE.INSTITUTEID.Equals(model.INSTITUTEID)
                && T.UNIVERSITY.UNIVERSITYID.Equals(model.UNIVERSITYID)
                ).ToList();
                
                return null;
                
            }



        }
    }
}
