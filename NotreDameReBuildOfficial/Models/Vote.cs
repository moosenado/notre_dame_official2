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

        public  List<PollOptionResult> GetPollOptionResult(int pollid){
            List<PollOptionResult> res = new List<PollOptionResult>();

            var items = from v in db.Votes
                               where v.poll_id == pollid
                               group v by v.poll_options_id into g
                               select new
                               {
                                   optionid = g.Key,
                                   count = g.Count()
                               };

            
            foreach (var item in items)
            {
                PollOptionResult obj = new PollOptionResult();
                obj.Option = db.Poll_options.SingleOrDefault(x => x.id == item.optionid);
                obj.OptionCount = item.count;
                res.Add(obj);
            }

            return res;
        }

        
    }

    public class PollOptionResult{
        public Poll_option Option { get; set; }
        public int OptionCount { get; set; }
    }
}