// Lớp trừu tượng Shape
public abstract class Shape
{
    private int _soDinh;

    public int so_dinh
    {
        get { return _soDinh; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Số đỉnh phải lớn hơn 0.");
            _soDinh = value;
        }
    }
}

// Lớp tam_giac kế thừa từ Shape
public class tam_giac : Shape
{
    public tam_giac()
    {
        so_dinh = 3; // Số đỉnh của tam giác luôn là 3
    }
}

// Ví dụ sử dụng
try
{
    Shape myShape = new tam_giac();
    Console.WriteLine($"Số đỉnh của hình: {myShape.so_dinh}");

    // Không cố gắng gán giá trị không hợp lệ cho số đỉnh nữa
    // myShape.so_dinh = -5;
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}