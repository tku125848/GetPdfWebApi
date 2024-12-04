# 使用 ASP.NET MVC 開發 WEB API

## 以輸出 PDF 作為範例

1. VS 2022 Create .Net Framework MVC Project
2. 選擇 MVC
3. 移除 js 、 css 與 cshtml 
4. 註解 RegisterBundles(BundleCollection bundles)
5. 更新 NuGet 套件
6. 新增 Context/pdf 目錄，並放置 pdf 檔案
7. 新增 Controllers/PdfController.cs