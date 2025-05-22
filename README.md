# PhotinoBlazorRclLoader Demo

**Important Notes**

*   When creating a directory structure like `Rcl/Rcl1`, the name `Rcl1` must match the name of the RCL library.
*   `CustomPhysicalFileProvider` is a security-sensitive implementation and should be used with caution.
    Specifically, it has the following security concerns:
    *   Using absolute paths: If the input subpath is an absolute path, it is used as is, potentially allowing access to files outside the intended directory.
    *   Path concatenation: Using `Path.Combine` without proper validation can lead to path traversal vulnerabilities.
    *   No file change monitoring: The `Watch` method returns `NullChangeToken.Singleton`, disabling file change monitoring.

## Overview

This demo shows how to dynamically load a Razor Class Library (RCL) into a PhotinoBlazor application.

## Prerequisites

*   .NET SDK 8.0 or later

## Instructions

1.  Create an `RCL` directory in the same directory as the PhotinoBlazorRclLoader executable.
    ```bash
    mkdir RCL
    ```
2.  Create a directory for your RCL library inside the `RCL` directory (e.g., `Rcl1`).
    ```bash
    mkdir RCL/Rcl1
    ```
3.  Publish your RCL library using the .NET SDK.
    ```bash
    dotnet publish -c Release -o RCL/Rcl1
    ```
4.  Place the DLL and resource files of the RCL library into the `RCL/Rcl1` directory.
5.  Run the PhotinoBlazorRclLoader executable. The application will dynamically load the RCL library and add a new menu item to the NavMenu.

## License

MIT License
This demo project is inspired by [Photino.Blazor](https://github.com/tryphotino/photino.Blazor).
Photino.Blazor is licensed under the Apache 2.0 license.

---
**注意事項**

*   作成するディレクトリ名（例：Rcl/Rcl1）において、Rcl1の名前はRCLライブラリの名前と一致する必要があります。
*   `CustomPhysicalFileProvider`はセキュリティ的に問題がある実装なので、注意して使用してください。
    具体的には、以下のセキュリティ上の懸念があります。
    *   絶対パスの使用：入力されたサブパスが絶対パスの場合、そのまま使用されるため、意図しないディレクトリ外のファイルにアクセスできる可能性があります。
    *   パスの連結：適切な検証なしに`Path.Combine`を使用すると、パストラバーサルの脆弱性につながる可能性があります。
    *   ファイル変更の監視なし：`Watch`メソッドは`NullChangeToken.Singleton`を返すため、ファイル変更の監視が無効になります。

## 概要

このデモは、PhotinoBlazorアプリケーションにRazorクラスライブラリ（RCL）を動的にロードする方法を示しています。

## 前提条件

*   .NET SDK 8.0 以降

## 手順

1.  PhotinoBlazorRclLoaderの実行ファイルと同じディレクトリに`RCL`ディレクトリを作成します。
    ```bash
    mkdir RCL
    ```
2.  `RCL`ディレクトリの中に、RCLライブラリ用のディレクトリを作成します（例：`Rcl1`）。
    ```bash
    mkdir RCL/Rcl1
    ```
3.  .NET SDKを使用してRCLライブラリをpublishします。
    ```bash
    dotnet publish -c Release -o RCL/Rcl1
    ```
4.  RCLライブラリのDLLファイルとリソースファイルを`RCL/Rcl1`ディレクトリに配置します。
5.  PhotinoBlazorRclLoaderの実行ファイルを実行します。アプリケーションはRCLライブラリを動的にロードし、NavMenuに新しいメニュー項目を追加します。

## ライセンス

MIT License
このデモプロジェクトは、[Photino.Blazor](https://github.com/tryphotino/photino.Blazor) から着想を得ています。
Photino.BlazorはApache2.0ライセンスでライセンスされています。
