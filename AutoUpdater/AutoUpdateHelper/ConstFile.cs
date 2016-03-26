/*****************************************************************
 * Copyright (C) Knights Warrior Corporation. All rights reserved.
 * 
 * Author:   圣殿骑士（Knights Warrior） 
 * Email:    KnightsWarrior@msn.com
 * Website:  http://www.cnblogs.com/KnightsWarrior/       http://knightswarrior.blog.51cto.com/
 * Create Date:  5/8/2010 
 * Usage:
 *
 * RevisionHistory
 * Date         Author               Description
 * 
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnightsWarriorAutoupdater
{
    public class ConstFile
    {
        public const string TEMPFOLDERNAME = "Temp";
        public const string CONFIGFILEKEY = "config_";
        public const string FILENAME = "AutoUpdater.config";
        public const string ROOLBACKFILE = "Quiz.exe";
        public const string MESSAGETITLE = "Cập nhật";
        public const string CANCELORNOT = "Đang tiến hành cập nhật. Bạn có muốn hủy bỏ quá trình?";
        public const string APPLYTHEUPDATE = "Chương trình cần khởi động lại để cập nhật các thay đổi. Bấm OK để khởi động lại chương trình!";
        public const string NOTNETWORK = "QuizApp cập nhật thất bại. QuizApp sẽ khởi động lại. Vui lòng thử cập nhật lại, hoặc liên hệ với quản trị viên.";
    }
}
