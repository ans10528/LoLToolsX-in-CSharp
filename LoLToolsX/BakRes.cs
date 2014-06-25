﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LoLToolsX
{
    class BakRes
    {

        /// <summary>
        /// 檔案備份/還原
        /// </summary>

        protected string installPath_m;  //

        public BakRes(string installPath)
        {
            installPath_m = installPath;
        }


        public void Prop(int Type)     //備份伺服器設定檔 (lol.properties)
        {
            //備份
            if (Type == 1)
            {
                try
                {
                    FileInfo fi = new FileInfo(installPath_m + @"\Air\lol.properties");
                    fi.CopyTo(Directory.GetCurrentDirectory() + @"\bak\server_prop\lol.properties",true);
                    MessageBox.Show("備份成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.log("伺服器設定檔 備份成功!", Logger.LogType.Info);
                }
                catch (Exception e)
                {
                    MessageBox.Show("備份失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.log("伺服器設定檔 備份失敗!", Logger.LogType.Error);
                    Logger.log(e);

                }
            }

            //還原
            if (Type == 2)
            {
                try
                {
                    FileInfo fi = new FileInfo(Directory.GetCurrentDirectory() + @"\bak\server_prop\lol.properties");
                    fi.CopyTo(installPath_m + @"\Air\lol.properties", true);
                    MessageBox.Show("還原成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.log("伺服器設定檔 還原成功!", Logger.LogType.Info);
                }
                catch (FileNotFoundException e2)
                {
                    MessageBox.Show("還原失敗 : 沒有備份 " , "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.log("伺服器設定檔 還原失敗 : 沒有備份檔案", Logger.LogType.Error);
                    Logger.log(e2);
                }

                catch (Exception e)
                {
                    MessageBox.Show("還原失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.log("伺服器設定檔 還原失敗!", Logger.LogType.Error);
                    Logger.log(e);
                }
            }

            //刪除備份
            if (Type == 3)
            {
                try
                {
                    FileInfo fi = new FileInfo(Directory.GetCurrentDirectory() + @"\bak\server_prop\lol.properties");
                    fi.Delete();
                    Logger.log("伺服器設定檔 備份刪除成功!", Logger.LogType.Info);
                    MessageBox.Show("刪除備份成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    Logger.log("伺服器設定檔 備份刪除失敗!", Logger.LogType.Error);
                    Logger.log(e);
                    MessageBox.Show("刪除備份失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }


        public void Lang(int Type)    //備份語言檔
        {

            string cd = Directory.GetCurrentDirectory();
            //備份
            if (Type == 1)
            {

                try
                {
                    File.Copy(installPath_m + @"\Game\DATA\Menu\fontconfig_en_US.txt",cd + @"\bak\lang\fontconfig_en_US.txt", true);
                    File.Copy(installPath_m + @"\Game\DATA\Menu\fontconfig_zh_TW.txt", cd + @"\bak\lang\fontconfig_zh_TW.txt", true);
                    File.Copy(installPath_m + @"\Game\DATA\CFG\Locale.cfg",cd + @"\bak\lang\Locale.cfg", true);
                    File.Copy(installPath_m + @"\Air\css\fonts.swf", cd + @"\bak\lang\fonts.swf", true);
                    File.Copy(installPath_m + @"\Air\css\fonts_zh_TW.swf", cd + @"\bak\lang\fonts_zh_TW.swf", true);
                    File.Copy(installPath_m + @"\Air\locale.properties", cd + @"\bak\lang\locale.properties", true);
                    Logger.log("語言檔 備份成功!", Logger.LogType.Info);
                    MessageBox.Show("備份成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    Logger.log("語言檔 備份失敗!", Logger.LogType.Error);
                    Logger.log(e);
                    MessageBox.Show("備份失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //還原
            if (Type == 2)
            {
                try
                {
                    File.Copy(cd + @"\bak\lang\fontconfig_en_US.txt", installPath_m + @"\Game\DATA\Menu\fontconfig_en_US.txt", true);
                    File.Copy(cd + @"\bak\lang\fontconfig_zh_TW.txt", installPath_m + @"\Game\DATA\Menu\fontconfig_zh_TW.txt", true);
                    File.Copy(cd + @"\bak\lang\Locale.cfg", installPath_m + @"\Game\DATA\CFG\Locale.cfg", true);
                    File.Copy(cd + @"\bak\lang\fonts.swf", installPath_m + @"\Air\css\fonts.swf", true);
                    File.Copy(cd + @"\bak\lang\fonts_zh_TW.swf", installPath_m + @"\Air\css\fonts_zh_TW.swf", true);
                    File.Copy(cd + @"\bak\lang\locale.properties", installPath_m + @"\Air\locale.properties", true);
                    Logger.log("語言檔 還原成功!", Logger.LogType.Info);
                    MessageBox.Show("還原成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FileNotFoundException e2)
                {
                    Logger.log("語言檔 還原失敗 : 沒有備份", Logger.LogType.Error);
                    Logger.log(e2);
                    MessageBox.Show("還原失敗 : 沒有備份 ", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch (Exception e)
                {
                    Logger.log("語言檔 還原失敗", Logger.LogType.Error);
                    Logger.log(e);
                    MessageBox.Show("還原失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Type == 3)
            {
                try
                {
                    File.Delete(cd + @"\bak\lang\fontconfig_en_US.txt");
                    File.Delete(cd + @"\bak\lang\fontconfig_zh_TW.txt");
                    File.Delete(cd + @"\bak\lang\Locale.cfg");
                    File.Delete(cd + @"\bak\lang\fonts.swf");
                    File.Delete(cd + @"\bak\lang\fonts_zh_TW.swf");
                    File.Delete(cd + @"\bak\lang\locale.properties");
                    Logger.log("語言檔 備份刪除成功! ", Logger.LogType.Info);
                    MessageBox.Show("備份刪除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    Logger.log(e);
                    MessageBox.Show("備份刪除失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        //語音
        public void Sound(int Type)
        {
            


            if (Type == 1)  //備份
            {

                string[] fsbFile = { "VOBank_zh_TW.fsb", "VOBank_zh_CN.fsb", "VOBank_en_US.fsb", "VOBank_ko_KR.fsb" };
                foreach (string file in fsbFile)
                {
                    try
                    {
                        File.Copy(installPath_m + @"\Game\DATA\Sounds\FMOD\" + file, Directory.GetCurrentDirectory() + @"\bak\sound\FMOD\" + file, true);
                    }
                    catch { }
                }
                
                try
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\bak\sound\air");
                    foreach (string newPath in Directory.GetFiles(installPath_m + @"\Air\assets\sounds\en_US\champions", "*.*", SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(installPath_m + @"\Air\assets\sounds\en_US\champions", Directory.GetCurrentDirectory() + @"\bak\sound\air"), true);
                    foreach (string newPath in Directory.GetFiles(installPath_m + @"\Air\assets\sounds\zh_TW\champions", "*.*", SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(installPath_m + @"\Air\assets\sounds\zh_TW\champions", Directory.GetCurrentDirectory() + @"\bak\sound\air"), true);
                    MessageBox.Show("備份成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.log("語音檔 備份成功!", Logger.LogType.Info);
                }
                catch (Exception e)
                {
                    Logger.log("語音檔 備份失敗!", Logger.LogType.Error);
                    Logger.log(e);
                    MessageBox.Show("備份失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            if (Type == 2) //還原
            {
                string[] fsbFile = { "VOBank_zh_TW.fsb", "VOBank_zh_CN.fsb", "VOBank_en_US.fsb", "VOBank_ko_KR.fsb" };
                foreach (string file in fsbFile)
                {
                    try
                    {
                        File.Copy(Directory.GetCurrentDirectory() + @"\bak\sound\FMOD\" + file, installPath_m + @"\Game\DATA\Sounds\FMOD\" + file, true);
                    }
                    catch { }
                }
                try
                {
                    foreach (string newPath in Directory.GetFiles(Directory.GetCurrentDirectory() + @"\bak\sound\air", "*.*", SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(Directory.GetCurrentDirectory() + @"\bak\sound\air",installPath_m + @"\Air\assets\sounds\en_US\champions"), true);
                    foreach (string newPath in Directory.GetFiles(Directory.GetCurrentDirectory() + @"\bak\sound\air", "*.*", SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(Directory.GetCurrentDirectory() + @"\bak\sound\air", installPath_m + @"\Air\assets\sounds\zh_TW\champions"), true);
                    MessageBox.Show("還原成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.log("語音檔 還原成功!", Logger.LogType.Info);
                }
                catch (System.IO.DirectoryNotFoundException err)
                {
                    Logger.log("語音檔 備份失敗 : 沒有還原檔可供還原", Logger.LogType.Error);
                    Logger.log(err);
                    MessageBox.Show("沒有還原檔可供還原", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
                catch (Exception e)
                {
                    Logger.log("語音檔 還原失敗!", Logger.LogType.Error);
                    Logger.log(e);
                    MessageBox.Show("還原失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }

            if (Type == 3)  //刪除
            {
                try
                {
                    Directory.Delete(Directory.GetCurrentDirectory() + @"\bak\sound\Air",true);
                    File.Delete(Directory.GetCurrentDirectory() + @"\bak\sound\FMOD\VOBank_ko_KR.fsb");
                    File.Delete(Directory.GetCurrentDirectory() + @"\bak\sound\FMOD\VOBank_zh_TW.fsb");
                    File.Delete(Directory.GetCurrentDirectory() + @"\bak\sound\FMOD\VOBank_zh_CN.fsb");
                    File.Delete(Directory.GetCurrentDirectory() + @"\bak\sound\FMOD\VOBank_en_US.fsb");
                    Logger.log("語音檔 刪除備份成功!", Logger.LogType.Error);
                    MessageBox.Show("備份刪除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.IO.FileNotFoundException err)
                {
                    Logger.log("語音檔 刪除備份失敗 : 沒有還原檔可供刪除", Logger.LogType.Error);
                    Logger.log(err);
                    MessageBox.Show("沒有還原檔可供刪除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);     
                }
                catch (Exception e)
                {
                    Logger.log("語音檔 刪除備份失敗", Logger.LogType.Error);
                    Logger.log(e);
                    MessageBox.Show("備份刪除失敗 \r\n 錯誤信息: " + e, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

    }
}
