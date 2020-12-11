using System;

namespace lab7 {
    public class ArticleNotFoundException : Exception{
        public ArticleNotFoundException(string message) : base(message){}
    }
}