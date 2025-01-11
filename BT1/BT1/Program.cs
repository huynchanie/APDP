using System;
using System.Collections.Generic;

class Task
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }

    public Task(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
        Status = false; // Mặc định chưa hoàn thành
    }

    public override string ToString()
    {
        return $"ID: {ID}, Tên: {Name}, Mô tả: {Description}, Trạng thái: {(Status ? "Hoàn thành" : "Chưa hoàn thành")}";
    }
}

class advanTask : Task
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string Creator { get; set; }

    public advanTask(int id, string name, string description, string creator)
        : base(id, name, description)
    {
        Creator = creator;
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now; // Khởi tạo ban đầu giống ngày tạo
    }

    public void UpdateStatus(bool status)
    {
        Status = status;
        UpdatedDate = DateTime.Now; // Cập nhật thời gian
    }

    public override string ToString()
    {
        return base.ToString() +
               $", Người tạo: {Creator}, Ngày tạo: {CreatedDate}, Ngày cập nhật: {UpdatedDate}";
    }
}

class TaskManager
{
    private List<advanTask> tasks = new List<advanTask>();

    public void Add(advanTask task)
    {
        tasks.Add(task);
        Console.WriteLine("Công việc nâng cao đã được thêm thành công!");
    }

    public void Delete(int id)
    {
        var task = tasks.Find(t => t.ID == id);
        if (task != null)
        {
            tasks.Remove(task);
            Console.WriteLine("Công việc nâng cao đã được xóa thành công!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy công việc nâng cao!");
        }
    }

    public void Update(int id, bool status)
    {
        var task = tasks.Find(t => t.ID == id);
        if (task != null)
        {
            task.UpdateStatus(status);
            Console.WriteLine("Công việc nâng cao đã được cập nhật thành công!");
        }
        else
        {
            Console.WriteLine("Không tìm thấy công việc nâng cao!");
        }
    }

    public void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Không có công việc nâng cao nào.");
            return;
        }

        Console.WriteLine("\nDanh sách công việc nâng cao:");
        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.WriteLine("\nMenu Quản lý Công việc Nâng cao:");
            Console.WriteLine("1. Thêm Công việc Nâng cao");
            Console.WriteLine("2. Cập nhật Trạng thái Công việc Nâng cao");
            Console.WriteLine("3. Xóa Công việc Nâng cao");
            Console.WriteLine("4. Hiển thị Danh sách Công việc Nâng cao");
            Console.WriteLine("5. Thoát");

            Console.Write("Chọn một tùy chọn: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    try
                    {
                        Console.Write("Nhập ID công việc: ");
                        int taskId = int.Parse(Console.ReadLine());
                        Console.Write("Nhập Tên công việc: ");
                        string name = Console.ReadLine();
                        Console.Write("Nhập Mô tả công việc: ");
                        string description = Console.ReadLine();
                        Console.Write("Nhập Tên người tạo: ");
                        string creator = Console.ReadLine();
                        taskManager.Add(new advanTask(taskId, name, description, creator));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi: {ex.Message}");
                    }
                    break;

                case "2":
                    try
                    {
                        Console.Write("Nhập ID công việc để cập nhật: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Nhập trạng thái (Hoàn thành/Chưa hoàn thành): ");
                        bool status = Console.ReadLine().ToLower() == "hoàn thành";
                        taskManager.Update(updateId, status);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi: {ex.Message}");
                    }
                    break;

                case "3":
                    try
                    {
                        Console.Write("Nhập ID công việc để xóa: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        taskManager.Delete(deleteId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi: {ex.Message}");
                    }
                    break;

                case "4":
                    taskManager.DisplayTasks();
                    break;

                case "5":
                    Console.WriteLine("Đang thoát chương trình.");
                    return;

                default:
                    Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng thử lại.");
                    break;
            }
        }
    }
}
