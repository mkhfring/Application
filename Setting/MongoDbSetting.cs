namespace ContactManagement.Setting
{
    public class MongoDbSetting
    {
        public string Host {set; get;}
        public string Port {set; get;}
        public string ConnectionSrting {
            get{
                return $"mongodb://{Host}:{Port}";
            }
        }
    }
}