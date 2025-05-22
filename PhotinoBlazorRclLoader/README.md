# PhotinoBlazorRclLoader Demo

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

---

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
