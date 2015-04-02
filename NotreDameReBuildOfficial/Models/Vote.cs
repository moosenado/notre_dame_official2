using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public partial class Vote
    {
        ndLinqClassDataContext db = new ndLinqClassDataContext();
        public void Insert(Vote vote)
        {
            db.Votes.InsertOnSubmit(vote);
            db.SubmitChanges();
        }
    }
}