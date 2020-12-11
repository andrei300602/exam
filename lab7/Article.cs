namespace lab7 {
    public class Article {
        private string _poroductName;
        private string _storeName;
        private float _costGoods;

        public Article(string poroductName, string storeName, float costGoods) {
            _poroductName = poroductName;
            _storeName = storeName;
            _costGoods = costGoods;
        }

        public string PoroductName {
            get => _poroductName;
            set => _poroductName = value;
        }

        public string StoreName {
            get => _storeName;
            set => _storeName = value;
        }

        public float CostGoods {
            get => _costGoods;
            set => _costGoods = value;
        }
    }
}