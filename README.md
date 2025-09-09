# Hệ Thống Bán Bánh
📸 Hình minh họa sau khi chạy code  

**Giao diện đăng nhập**  
<img width="702" height="487" alt="image" src="https://github.com/user-attachments/assets/3dacae80-1d66-4952-86ca-e444eaa0254f" />

---

**Giao diện trang chủ**  
<img width="756" height="470" alt="image" src="https://github.com/user-attachments/assets/517f2ab7-a197-40f5-b881-4a886291dac5" />

---
## 📌 Giới thiệu
Đây là ứng dụng **desktop** được xây dựng bằng **C# Windows Forms**.  
Mục đích của dự án là quản lý cửa hàng bán bánh: quản lý sản phẩm, khách hàng, đơn hàng, thống kê,...

## 🛠️ Công nghệ sử dụng
- Ngôn ngữ: **C#**
- Mô hình : **MVC**
- Framework: **.NET Windows Forms**
- Cơ sở dữ liệu: **SQL Server**
- IDE khuyến nghị: **Visual Studio 2019/2022**

---

## 🚀 Hướng dẫn cài đặt & chạy



### 1. Clone project từ GitHub
```bash
git clone https://github.com/tranducnam01/Hethongbanbanh.git
cd Hethongbanbanh

2. Tạo Database từ SQL Server dựa vào Diagram
<img width="1129" height="703" alt="image" src="https://github.com/user-attachments/assets/2b95ddcc-7528-4bc2-b4cf-529f669474a3" />
3. Cấu hình chuỗi kết nối

Mở file App.config trong project, chỉnh lại phần connectionStrings cho phù hợp với SQL Server trên máy.
    <connectionStrings>
      <add name="QLBanHangConnection"
           connectionString="Data Source=.;Initial Catalog=QLBanHang;Integrated Security=True" 
           providerName="System.Data.SqlClient" />
    </connectionStrings>







