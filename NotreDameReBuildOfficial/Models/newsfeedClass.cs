using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotreDameReBuildOfficial.Models
{
    public class newsfeedClass
    {
        public string file { get; set; } //get file name string

        ndLinqClassDataContext objNews = new ndLinqClassDataContext(); //link file to the designer.cs file
        public IQueryable<news_article> getArticles() //Query directly from the database
        {
            var allArticles = objNews.news_articles.Select(x => x); //only take the three most recent articles from the database
            return allArticles;
        }
        public IQueryable<news_article> getTopArticles() //Query directly from the database
        {
            var allTopArticles = objNews.news_articles.OrderByDescending(x => x.Id).Take(3); //only take the three most recent articles from the database
            return allTopArticles;
        }
        public news_article getArticlesByID(int _id) //pass chosen id to this function which matches id to id in the table
        {
            var all_articles_id = objNews.news_articles.SingleOrDefault(x => x.Id == _id);
            return all_articles_id;
        }

        public bool insertArticle(news_article news_article_table) //Pass an instance of our table (all form fields)
        {
            using (objNews) //open/close connection to database
            { 
                objNews.news_articles.InsertOnSubmit(news_article_table); //pass info to table
                objNews.SubmitChanges(); //insert to database table
                return true;
            }
        }
       
        public bool articleUpdate(int _id, string _title, string _date, string _author, string _image, string _article)
        {
            using (objNews)
            {
                var update = objNews.news_articles.Single(x => x.Id == _id); //SELECT where chosen ID matches ID in the table
                update.title = _title;
                update.date = _date;
                update.author = _author;
                update.image = _image;
                update.article = _article;
                objNews.SubmitChanges(); // Update database
                return true;
            }
        }

        public bool articleDelete(int _id)
        {
            using (objNews)
            {
                var delete = objNews.news_articles.Single(x => x.Id == _id);
                objNews.news_articles.DeleteOnSubmit(delete); //delete user on submission
                objNews.SubmitChanges(); //commit deletetion change to the database
                return true;
            }
        }

        public bool featureUpdate(int _id, string _featured)
        {
            using (objNews)
            {
                var update = objNews.news_articles.Single(x => x.Id == _id); //SELECT where chosen ID matches ID in the table
                update.featured = _featured;
                objNews.SubmitChanges(); // Update database
                return true;
            }
        }

    }
}