using System;
using System.Collections.Generic;

namespace lab7 {
    public class Store {
        private List<Article> _articles;

        public Store() {
            _articles = new List<Article>();
        }

        public List<Article> Articles {
            get => _articles;
        }

        public void addNewArticle(string name = "", string store = "", int cost = 0) {
            Article article = new Article(name, store, cost);
            _articles.Add(article);
        }

        public Article getArticleByIndex(int index) {
            Article article;
            try {
                article = _articles[index];
            }
            catch (Exception) {
                throw new ArticleNotFoundException("Не знайдено товару за таким індексом");
            }

            return article;
        }

        public Article getArticleByName(string name) {
            Article article = null;
            foreach (var art in _articles) {
                if (art.PoroductName == name) {
                    article = art;
                }
            }

            if (article == null) {
                throw new ArticleNotFoundException("Не знайдено товару за такою назвою");
            }

            return article;
        }
    }
}