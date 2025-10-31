namespace Question3
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }
    
    public interface IRepository<T> where T : Entity
    {
        void Add(T item);
        void Remove(T item);
        void Save();
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
    
    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            _items.Add(item);
        }

        public void Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            _items.Remove(item);
        }

        public void Save()
        {
            // Simulate saving to database or file
            Console.WriteLine("Changes saved to data source.");
        }

        public IEnumerable<T> GetAll()
        {
            return _items;
        }

        public T GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }
    }
    
    public class Student : Entity
    {
        public string Name { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            IRepository<Student> studentRepo = new GenericRepository<Student>();
            
            studentRepo.Add(new Student { Id = 1, Name = "Alice" });
            studentRepo.Add(new Student { Id = 2, Name = "Bob" });
            studentRepo.Save();
            
            Console.WriteLine("All students:");
            foreach (var s in studentRepo.GetAll())
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}");
            }
            
            var student = studentRepo.GetById(1);
            Console.WriteLine($"\nStudent with ID 1: {student.Name}");
            
            studentRepo.Remove(student);
            studentRepo.Save();

            Console.WriteLine("\nAfter removal:");
            foreach (var s in studentRepo.GetAll())
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}");
            }
        }
    }
}