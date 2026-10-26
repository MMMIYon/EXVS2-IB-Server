# AGENTS.md（1.1.1 源码工作区）

- 本工作区是 Server-Infinite 1.1.1 源码，已经移植了 1.1.3 的变动和路线战/徽章改造，详见 `移植说明-1.1.1.md`。参照实现是 `..\NEW Server Infinite 1.1.3 - workspace\_analysis\server_build`。
- 用户要求：不要往工作区放图片（徽章图由用户自己放到 `wwwroot\images\Badge`）。
- 没有 git。原始源码副本在 `..\_port\base111`，可用 `git diff --no-index` 对比。
- 编译：`cd Server-Infinite; dotnet build -c Release`；发布：`dotnet publish -c Release -r win-x64 -o <dir>`。
- 迁移：已全局安装 dotnet-ef 9.0.2（`$env:USERPROFILE\.dotnet\tools`）。路线战迁移 ID 固定为 `20261026034120_AddRouteBattleData`，不重复建 stage_save_data 表（`..\_port\fix_migration111.py`）。dotnet ef 运行会在 Server-Infinite\Logs 留下日志，用完删除。
- 测试：用 `..\_port\run111.ps1 -Dir <exe目录> -Db <库> -Scripts route_test.py,badge_test.py|regress.py -Tag x`，端口 28090（28080 不要动）。测试目录有 `_t111`（新版）、`_tbase`（原版 1.1.1）、`_tw3`（1.1.3 修改版）；对比用 `..\_port\rcmp.py`。
- `ResetBadgeExpOnChange` 默认 true，不要擅自修改；路线战不累加 TriadBuddyPoint 是用户确认过的。
