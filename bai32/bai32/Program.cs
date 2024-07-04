class Program
{
    static void Main(string[] args)
    {
        Person obs = new Student { Name = "Nguyễn Văn Nam", Major = "ICT" };

        // Kiểm tra obs là Student hay không
        if (obs is Student)
        {
            // Gọi phương thức kpi()
            ((Student)obs).kpi();
        }
        else
        {
            Console.WriteLine("obs is not a Student object.");
        }

        // Nếu Name và Major không hỗ trợ get, set
        // Sẽ xảy ra lỗi khi biên dịch vì các thuộc tính sẽ không thể truy cập được.
    }
}