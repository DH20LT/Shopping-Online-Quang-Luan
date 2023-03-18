# Phân Tích Lỗi

Lỗi xuất hiện tại Component NavigationMenuViewComponent và View ProductManagement

## Lỗi 1: Về Component NavigationMenuViewComponent

![image](https://user-images.githubusercontent.com/45689286/226090634-521b7226-f588-49f0-bbbb-f9f8ef2cf910.png)

Do liên kết `~/Views/Shared/Component/NavigationMenuViewComponent/Default.cshtml` đến file không tồn tại.

=> Cần tạo ra file này.

## Lỗi 2: Về View ProductManagement

![image](https://user-images.githubusercontent.com/45689286/226090808-aaa661e2-6829-48b7-aa9e-67b3474261f7.png)

Không tồn tại namespace với tên là **ShoppingOnline** => của Luân là **ShoppingOnline1** 
