using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public partial class poll
    {
        ndLinqClassDataContext db = new ndLinqClassDataContext();

        public List<Poll_option> options { get; set; }

        public poll GetRandomQuestion()
        {
            poll res = new poll();

            int question_count = db.polls.Count();
            Random rnd = new Random();
            int qn = rnd.Next(1, question_count + 1);

            res = db.polls
                .OrderBy(x => x.id)
                .Skip(qn - 1)
                .Take(1)
                .SingleOrDefault();

            res.options = new List<Poll_option>();
            res.options = db.Poll_options
                .Where(x => x.poll_id == res.id)
                .ToList();

            return res;
        }
    }
}