using System;
using System.Collections.Generic;

class SinhVien
{
    public string MSSV { get; set; }
    public string HoTen { get; set; }
    public double DiemToan { get; set; }
    public double DiemLy { get; set; }
    public double DiemHoa { get; set; }

    public double DiemTrungBinh
    {
        get { return (DiemToan + DiemLy + DiemHoa) / 3; }
    }
}

class bai31
{
    static List<SinhVien> danhSachSinhVien = new List<SinhVien>();

    internal static List<SinhVien> DanhSachSinhVien { get => danhSachSinhVien; set => danhSachSinhVien = value; }

    static void Main(string[] args)
    {
        NhapSoLuongSinhVien();
        NhapThongTinSinhVien();
        TinhDiemTrungBinh();
        HienThiThongTinSinhVien();
        HienThiSinhVienDiemTrungBinhCao();
    }

    static void NhapSoLuongSinhVien()
    {
        int soLuongSinhVien;
        while (true)
        {
            try
            {
                Console.Write("Nhập số lượng sinh viên: ");
                soLuongSinhVien = int.Parse(Console.ReadLine());
                if (soLuongSinhVien > 0)
                    break;
                else
                    Console.WriteLine("Số lượng sinh viên phải lớn hơn 0. Vui lòng nhập lại.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Vui lòng nhập một số nguyên.");
            }
        }

        for (int i = 0; i < soLuongSinhVien; i++)
        {
            SinhVien sv = new SinhVien();
            DanhSachSinhVien.Add(sv);
        }
    }

    static void NhapThongTinSinhVien()
    {
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            Console.WriteLine($"Nhập thông tin sinh viên {DanhSachSinhVien.IndexOf(sv) + 1}:");
            Console.Write("Mã số sinh viên: ");
            sv.MSSV = Console.ReadLine();
            Console.Write("Họ và tên: ");
            sv.HoTen = Console.ReadLine();
            while (true)
            {
                try
                {
                    Console.Write("Điểm toán: ");
                    sv.DiemToan = double.Parse(Console.ReadLine());
                    Console.Write("Điểm lý: ");
                    sv.DiemLy = double.Parse(Console.ReadLine());
                    Console.Write("Điểm hóa: ");
                    sv.DiemHoa = double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Vui lòng nhập một số thực.");
                }
            }
        }
    }

    static void TinhDiemTrungBinh()
    {
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            Console.WriteLine($"Điểm trung bình của sinh viên {sv.HoTen} là: {sv.DiemTrungBinh:F2}");
        }
    }

    static void HienThiThongTinSinhVien()
    {
        Console.WriteLine("\nThông tin các sinh viên:");
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            Console.WriteLine($"Mã số: {sv.MSSV}, Họ và tên: {sv.HoTen}, Điểm trung bình: {sv.DiemTrungBinh:F2}");
        }
    }

    static void HienThiSinhVienDiemTrungBinhCao()
    {
        bool timThay = false;
        foreach (SinhVien sv in DanhSachSinhVien)
        {
            if (sv.DiemTrungBinh > 9.5)
            {
                Console.WriteLine($"Sinh viên có điểm trung bình cao nhất: Mã số: {sv.MSSV}, Họ và tên: {sv.HoTen}, Điểm trung bình: {sv.DiemTrungBinh:F2}");
                timThay = true;
                break;
            }
        }
        if (!timThay)
            Console.WriteLine("Không có sinh viên nào có điểm trung bình trên 9.5.");
    }
     static int CountStudentsWithGPAOver5(List<SinhVien> students)
    {
        int count = 0;
        foreach (var student in students)
        {
            if (student.DiemTrungBinh <= 5.0)
                continue;
            count++;
        }
        return count;
    }
     static void SortByAverageAsc(List<SinhVien> students)
    {
        students.Sort((s1, s2) => s1.DiemTrungBinh.CompareTo(s2.DiemTrungBinh));
    }
    static void SortByNameAlphabetically(List<SinhVien> students)
    {
        students.Sort((s1, s2) => s1.HoTen.CompareTo(s2.HoTen));
    }
    static void WriteStudentsToFile(List<SinhVien> students, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var student in students)
            {
                writer.WriteLine($"{student.HoTen},{student.DiemTrungBinh}");
            }
        }
    }
   static List<SinhVien> ReadStudentsFromFile(string fileName)
    {
        List<SinhVien> students = new List<SinhVien>();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string name = parts[0];
                double average = double.Parse(parts[1]);
                students.Add(new SinhVien { HoTen = name, DiemToan = average });
            }
        }
        return students;
    }





}
