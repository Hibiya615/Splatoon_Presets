import os
import glob

def get_script_directory():
    """获取脚本所在的真实目录"""
    # 方法1：使用 __file__ 获取脚本路径
    script_path = os.path.abspath(__file__)
    script_dir = os.path.dirname(script_path)
    return script_dir

def convert_txt_to_md():
    # 获取脚本所在目录
    script_dir = get_script_directory()
    
    print("=== 调试信息 ===")
    print(f"Python 报告的当前工作目录: {os.getcwd()}")
    print(f"脚本实际所在目录: {script_dir}")
    
    # 总是使用脚本所在目录
    target_dir = script_dir
    
    print(f"\n将在以下目录查找 .txt 文件: {target_dir}")
    print("目录中的文件:")
    
    files = os.listdir(target_dir)
    for file in files:
        print(f"  - {file}")
    
    # 切换到目标目录
    os.chdir(target_dir)
    
    # 查找 .txt 文件
    txt_files = glob.glob("*.txt")
    
    if not txt_files:
        print("\n❌ 没有找到 .txt 文件")
        return
    
    print(f"\n找到 {len(txt_files)} 个 .txt 文件:")
    for file in txt_files:
        print(f"  - {file}")
    
    confirm = input(f"\n确认转换这 {len(txt_files)} 个文件？(y/n): ").lower().strip()
    if confirm != 'y':
        print("操作已取消")
        return
    
    print("\n开始转换...")
    success_count = 0
    
    for txt_file in txt_files:
        filename = os.path.splitext(txt_file)[0]
        md_file = f"{filename}.md"
        
        try:
            # 读取原文件
            with open(txt_file, 'r', encoding='utf-8') as f:
                content = f.read()
            
            # 写入新文件
            with open(md_file, 'w', encoding='utf-8') as f:
                f.write(f"# {filename}\n\n```\n{content}\n```\n")
            
            # 删除原文件
            os.remove(txt_file)
            print(f"✅ {txt_file} -> {md_file}")
            success_count += 1
            
        except Exception as e:
            print(f"❌ 转换失败 {txt_file}: {e}")
    
    print(f"\n🎉 完成！成功转换了 {success_count}/{len(txt_files)} 个文件")

if __name__ == "__main__":
    convert_txt_to_md()