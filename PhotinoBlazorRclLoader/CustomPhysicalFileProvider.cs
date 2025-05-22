// Copyright (c) 2025 ssaattww. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.Primitives;

namespace PhotinoBlazorRclLoader
{
    public class CustomPhysicalFileProvider : IFileProvider
    {
        private readonly string _root;

        /// <summary>
        /// コンストラクタでルートディレクトリを指定します。
        /// </summary>
        /// <param name="root">物理ディレクトリへのパス</param>
        public CustomPhysicalFileProvider(string root)
        {
            if (string.IsNullOrEmpty(root))
                throw new ArgumentNullException(nameof(root));

            // 絶対パスに変換して保持
            _root = Path.GetFullPath(root);
        }

        /// <summary>
        /// 指定されたサブパスに対応するファイル情報を取得します。
        /// 入力が絶対パスの場合は、そのパスを直接利用してファイル情報を返します。
        /// </summary>
        public IFileInfo GetFileInfo(string subpath)
        {
            if (string.IsNullOrEmpty(subpath))
                return new NotFoundFileInfo(subpath);

            string fullPath;
            if (Path.IsPathRooted(subpath))
            {
                fullPath = Path.GetFullPath(subpath);
            }
            else
            {
                string relativePath = subpath.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                fullPath = Path.Combine(_root, relativePath);
                fullPath = Path.GetFullPath(fullPath);
            }

            if (File.Exists(fullPath))
            {
                return new PhysicalFileInfo(new FileInfo(fullPath));
            }

            return new NotFoundFileInfo(subpath);
        }

        /// <summary>
        /// 指定されたサブパスに対応するディレクトリ内容を取得します。
        /// 入力が絶対パスの場合はそのまま利用、それ以外はルートパスと結合
        /// </summary>
        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            string fullPath;
            // 入力が絶対パスの場合はそのまま利用、それ以外はルートパスと結合
            if (!string.IsNullOrEmpty(subpath) && Path.IsPathRooted(subpath))
            {
                fullPath = Path.GetFullPath(subpath);
            }
            else
            {
                string relativePath = string.IsNullOrEmpty(subpath)
                    ? string.Empty
                    : subpath.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                fullPath = Path.Combine(_root, relativePath);
                fullPath = Path.GetFullPath(fullPath);
            }

            if (!Directory.Exists(fullPath))
            {
                return NotFoundDirectoryContents.Singleton;
            }

            var directoryInfo = new DirectoryInfo(fullPath);
            var entries = new List<IFileInfo>();

            foreach (var entry in directoryInfo.GetFileSystemInfos())
            {
                if (entry is FileInfo fileInfo)
                {
                    entries.Add(new PhysicalFileInfo(fileInfo));
                }
                else if (entry is DirectoryInfo dirInfo)
                {
                    entries.Add(new PhysicalDirectoryInfo(dirInfo));
                }
            }

            return new EnumerableDirectoryContents(entries);
        }

        /// <summary>
        /// ファイル変更の監視を開始します。ここではシンプルに NullChangeToken を返します。
        /// </summary>
        public IChangeToken Watch(string filter)
        {
            // 実際に変更監視を行う場合は FileSystemWatcher 等と連携する
            return NullChangeToken.Singleton;
        }
    }

    /// <summary>
    /// ディレクトリの内容をラップする EnumerableDirectoryContents の実装例
    /// </summary>
    public class EnumerableDirectoryContents : IDirectoryContents
    {
        private readonly IEnumerable<IFileInfo> _entries;

        public EnumerableDirectoryContents(IEnumerable<IFileInfo> entries)
        {
            _entries = entries;
        }

        public bool Exists => true;

        public IEnumerator<IFileInfo> GetEnumerator() => _entries.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _entries.GetEnumerator();
    }
}
