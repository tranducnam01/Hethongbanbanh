# Hệ Thống Bán Bánh

## 📌 Giới thiệu
Đây là ứng dụng **desktop** được xây dựng bằng **C# Windows Forms**.  
Mục đích của dự án là quản lý cửa hàng bán bánh: quản lý sản phẩm, khách hàng, đơn hàng, thống kê,...

## 🛠️ Công nghệ sử dụng
- Ngôn ngữ: **C#**
- Mô hình : **MVC**
- Framework: **.NET Windows Forms**
- Cơ sở dữ liệu: **SQL Server**
- IDE khuyến nghị: **Visual Studio 2019/2022**


## 🚀 Hướng dẫn cài đặt & chạy
📸 Hình minh họa sau khi chạy code

Giao diện đăng nhập
<img width="702" height="487" alt="image" src="https://github.com/user-attachments/assets/dbf58697-2da7-4c91-a94a-91422459d43e" />

Giao diện trang chủ
<img width="702" height="487" alt="image" src="https://github.com/user-attachments/assets/c7cb6349-1cb1-4b6b-b5ab-1a2bd5df0ddd" />

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


