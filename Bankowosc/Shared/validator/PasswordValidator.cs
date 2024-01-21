﻿using System.ComponentModel.DataAnnotations;

namespace Bankowosc.Shared.validator;

public class PasswordValidator : ValidationAttribute
{

    private string ErrorMessage = "Too week";

    
    public override bool IsValid(object? value)
    {
        if (value is string password)
        {
            if (password.Length < 8)
            {
                ErrorMessage = "Hasło jest za krótkie";
                return false;
            }
            
            if (!password.Any(char.IsUpper))
            {
                ErrorMessage = "Hasło musi mieć conajmniej jedną dużą litere.";
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                ErrorMessage = "Hasło musi zawierać conajmniej jedną małą litere";
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                ErrorMessage = "Hasło musi zawierać conajmniej jedną jedną cyfre";
                return false;
            }

            if (!password.Any(IsSpecialCharacter))
            {
                ErrorMessage = "Hasło musi zawierać znak specjalny";
                return false;
            }

            foreach (string bat in batPassword)
            {
                if (bat.Equals(password))
                {
                    ErrorMessage = "To jest powszechne hasło użyj innego";
                    return false;
                }
            }

            // Password meets all criteria
            return true;
        }
        return false;
    }

    private static bool IsSpecialCharacter(char c)
    {
        return !char.IsLetterOrDigit(c);
    }

    public override string FormatErrorMessage(string name)
    {
        return ErrorMessage;
    }

    private string[] batPassword = {
"L58jkdjP!", "P@ssw0rd", "!QAZ2wsx", "1qaz!QAZ", "P030710P$E4O", "1qaz@WSX", "ZAQ!2wsx", "!QAZxsw2", "%E2%82%AC", "NICK1234-rem936", "xxPa33bq.aDNA", "!QAZ1qaz", "g00dPa$$w0rD", "Jhon@ta2011", "Nloq_010101", "1qazZAQ!", "zaq1ZAQ!", "Ab.1234567", "ZAQ!xsw2", "Pa$$w0rd", "Mosquito@13", "onlyOne4-myXworld", "Euq8pvHrnpSSdymIZQx+", "Dybik.66.", "Az.1996.", "Art_06.05", "Al#kS3!kSj0xX", "zaq1!QAZ", "Qwerty1!", "P@$$w0rd", "Password1!", "F5_mK6Vn", "eXpl0it|ng", "abcd!EFG!123", "ZAQ!1qaz", "xx85.eNK7a8M2", "$Tatyana09$", "Samantha1!", "$RFV4rfv", "!QAZzaq1", "!QAZxsw2#EDCvfr4", "Pw_310la", "P@55w0rd", "..oO3xPZokK6", "OmL47#yW", "NCC-1701", "Marco1997!", "M3hm3t_k", "LOLO-909", "Juninho1999@", "jack33_lWR9L", "Hengsha_2_23", "gNdb4b3$", "GiA^Sox-291", "Gfhjkm_2", "Bmw_540_i", "bb33BB##", "aZiA-J64", "5tgbBGT%", "4c@J&$sS", "2wsx#EDC", "1Password!", "17-Jan-78", "ZXCvbn123!", "ZGMF-X20", "Zachary1!", "@YZA6y9aduBadu", "@YSU9e2eXUNupa", "ysQN*AXT5oKP", "Yr7$jiRO", "ynaJAWave$U6Y4", "y9Y%aTy3EpYXUQ", "xxO03Olo.QHZ2", "xx0trl.Ebiq5E", "xsw2#EDC", "X-rated9437", "X-rated5562", "X-rated1893", "$XeaRoMs8upWyBtS", "Ww3Ymb8f$fhr", "Wolki1H%ig", "wL7320JQ!8", "whigginb1-S739RHT8", "War3xpansion_", "W8STED_R0x", "w!2E3B#pszD9fXAv", "W0mbatdrug$", "VqGbShD5BmMw$Lup", "Vixens.comreaper999MOR098GO", "VITALINA_1992", "VcW19uNO3o!p", "v9ActnwQoy$Y", "V6#WnsBLDES2!7Zg", "UXUdE%U7uqeryG", "umyZu@APY7ytYQ", "u@eLy2y6u#erY4", "Tm3A..M2", "Tickled.comreaper999MOR098GO", "taQU5ybY5e#YbA", "t69_XDKx", "sUtY8yLaDyhe!A", "Super.168", "STALKER.1993", "S!OsoP8duGDbqEcH", "Sorboro@14", "Some@1128", "Sky!blu3", "sk68xzd!3NhY", "Sj2323!!", "Simpsons1#", "Shad0w*10*1", "S=#Et!041mAkToeZ", "Seriy.290199", "SCCUTER_9", "s5j1Ko6Sa#", "REN.2007", "RaBe_1968", "R9lk7..y7IE.", "QWERTY_123", "!@QW12qw", "*Q_sS886004_", "..QfZe5pxdVA", "!QAZ2wsx#EDC", "!Qaz2wsx", "!QA2ws3ed", "P@ssW0rd", "PRAT123*", "Play-b0y", "Password1.", "Passw0rd!", "PAA-0001", "onlyOne4-eXcesS", "Oleg.Kapustin_95", "Ocgatk2-Llaveatk2", "NY#77G-f", "Number123456789!!!", "No_Hack8", "??????N?N?12345", "Nicole_1", "n6mjx7yQ@orw", "m#XI!RZYvh681=Fn", "Mumi-l0v", "Monster_1", "Money4me2!", "ManicSon-love908", "MAGODEOZ_9", "Mach1_03", "m!6jAnlik0Mt97", "M2141-01", "LucXakK_00", "LT95vv@s", "L_h1o2rn", "Lena_9Tanya", "LazerBoy_1", "Lavey-Lavey666", "LA%u9E5y2YVuVA", "Killer_123", "Kauguri98-02", "Katya13.12", "Katty_Astro1", "Karina_1996", "Jonbm86!", "Joed++?8", "_JJJDDDl29_", "Jhood22-december", "Jesus777!", "Jerk921@", "J33p3rs!", "iPhone43.", "INMDinmd_93", "iA!VK#S=72q0UjG4", "i05#2VWET!GfCO7M", "HXUNS2-M", "hansel_nEYz4", "GudronBaton.12", "goofY4$5", "Godisgreat@78", "GM!02041508", "GGH_555_1", "Geo'rge5", "gAgY4UzA%EWAQu", "g8NJr*QxcCkF", "fZF2LgUr!A", "Fylh.irf888", "Fuckyou123!", "Fuck0ff!", "Froob!23", "Fowler-01", "!Fish72!", "Fi2t_5ha", "Fetish.combeezer4topper4", "Fenice1.", "*F2i9UfcRdZ3", "eZE3A#E7U9APu6", "e#y9A4A%EmUqYB", "ETaQaTeve2A#y2", "$emperF1", "Elogos_11", "Elogos_10", "Election@09", "Ekips123_", "#EDCvfr4", "EC_.D7fVQ", "e5yRUDu@eDYZYB", "e0POR0xn8Kt8lRk96+", "Dragoness.1", "Dragon_6.9", "dQSp_h2I", "DJ3lyKi!", "DIAnaEK_23", "DFj8979789!ths", "DD!mstwy28", "dcbrown5-ENujypEGYsu7eh", "DBM_1211", "DaS.g3ht", "!cuCIJ_LN942q0EW", "Creeper_4", "Creeper_3", "cinnamon^21isonIRC", "CBDBL3xi@", "c2.99792E8", "Buster123!", "Bradley1!", "Boryna_evVA4", "Bomber52!", "Bolinha@2008", "Black2055!", "BE%eTYjaguWA7A", "Beaver44-uncleewj", "BaD.BoY_007", "AZaz!@12", "AycO.17111995", "Atao!4V1hwp9", "AsiraK@1892", "*ASGHASGH1", "ASdf12#$", "Anders_54", "Anderley@07", "Amiral24-24", "Alph@5380", "allthe_y7FGb", "AJN6969-DARBY1", "AH-DPqd9", "afRu0dYen!1z", "AFFIL97$57M", "AFFIL5478M$", "Adobe_01", "AC_DCmp3", "aaNN3X.P", "AAA..9aFctqxKSFY", "A5ezygyJa4y#eL", "9j!7cT_3lHUOLM#Q", "91jL.rHI", "7=zARJK#bo928u4i", "7!k19Cglxs_52zAr", "7ceM0s!#o4x8NG29", "74ywcO.y", "74N.a4bW", "74BU.BzI", "6yhnMJU&", "6aNAqU#esA7u3Y", "666.Meta", "5YJY#ELeLu6YLe", "5#o7!0qfvWdI46DF", "51c0J!CRVNyo", "4xXx_ab0ot", "4rfv$RFV", "!4PolskaViza$", "4!gEb6HGSOeP", "49eS#t#A", "403_NIRA", "3SKpil#C!1=62ehH", "3Lgn5!9IMBHb", "39603610-Ba", "37947952Lc$", "302C.I.D.", "2YD*bJeN", "2wsx@WSX", "2ldNp_7735", "!2h7=aol64#Exq0Q", "2GqHir*EhjSa", "25Uw1gF.", "1Runner!", "1_Marian", "1976_Mikhail", "18.08.M.5", "1702_ED_New", "1475aA##", "141791.htmTranslator", "12#$qwER", "1??2N?3N?4??", "127Hour$291", "123qwe!@#QW", "11!!qqAA", "0!g2437k8D#NTzUe", "0ERin4j_", "ZZyZZ56.", "ZzR4HXUeKWx$", "ZzPgE23y$Dvr", "zzOT901d_1984", "zz0rr0ZZ#", "Z@Y@tS20892", "zYs.obJzWo07", "zyquXYZuhe6E$e", "Zyjxrf97_16_0", "Zybov.1979", "zyab72K!", "zy$a9E8uvu!AJe", "ZXji99_ASW", "zxC_PoiU7", "zxc_LK12as", "Zxcdwer_24", "Zxcaq1@w", "Zxc_6044684", "Zx_040790", "ZX.02122008", "zweRTfc5N4n7u6#q", "ZVER.1975", "Z_v#49365ckRXlW7", "ZU$U#u8ETaBaTA", "Z_utybq2", "ZUTAmagY@EBu6e", "Zunechka23.01.", "Zu.lu971", "ZtU3#vYjG$", "Zsw23$rfv", "zStDba*vN6qF", "zse4ZSE$", "Zs12345!", "ZRCue2fc$pX4", "zq@R$PW8bhGT", "ZQ48$N9LWxS*", "ZpWTN_lM7", "Zp$AVUaMgh9fqubn", "zP5QmEu*9saA", "Zorro_666", "ZoRRo_1987", "ZO$qP#U5", "!ZooMan1", "Zont!123#", "Zoloto_12", "Zolotinka_83", "ZNBy*2Vh", "znaj2_8Ety", "zN8_nvFfT", "zMy7D$YTfP", "Zmrzl1na!", "Zm$K23aihH*4qJEc", "zmID~1B3d", "..ZmeC4YEz58", "$ZKZ9UCWA4$", "Zk.vbire1999", "zkhh!7!MnS", "zk39g0odPOPfr$$", "Zjy*3iRGUTCDoaNw", "ZJX44_08ex", "ZJSwCGjkqM*7", "Z#ji6sk5_3Lc01VO", "ZIZ6_3zD", "Zippermaster-team3x", "Zip_7351", "Ziocul.123", "Zinzoe@6", "ZINGER-20", "Zind@giN@205", "ZIma.3000", "Zima1979!", "Zim52115#", "Zikank@_2010", "Ziggs05!**", "ZiEbOlD_199", "Zie1987..", "Zidane04!", "zib4-DAZ", "zi.A5Ooqxqmj", "zI8Flp4H1a!", "zhzwcF3!", "ZHyY2UP_7SK4Lten", "zhuO2K_1#dPargfG", "Zhop_en235", "ZgWju.J3", "ZgM.Uvjo6TDF", "ZGIA_2009", "ZGd-9rm-rRK-vs6", "zG0Te19L8W#kf_u3", "ZF!8fxXHovN3", "ZEZgEwQq1x!&amp", "ZeV.xoy0Ioqb", "ZE!uvAZyrYnE3u", "ze$UQYPUteQa6u", "Zeta.312", "Zeroshift_23", "Zep4Evr!", "zenitEThelios44M-4", "ZenDanFaj25!", "Zelja-007", "Zeitfahren-05", "Zegerid@108", "Zdw96k.l", "z#D3NvEw0H!ou_nK", "ZbR#VI_c3myf8!z2", "Zballa24!", "ZAZEWu3uNa%YNy", "zAxScDvF_123", "ZA$uzEty3EXu2a", "Zatvon0.", "Zathras_1", "Zasranka-87", "Zasada52*", "Za!rOQ7_#I9PG48D", "Zarina88.", "ZaRa_1988S", "ZAQ!zaq1", "ZaqwsX7679bgHrty!", "ZaQE$aVyde4uXu", "Zaq%212wsx", "Zaq1xsw@", "zaq1@WSXcde3", "zaq1@WSX", "Zaq1!qaz", "zaq1!Qaz", "zaq1#EDC", "Zaq1-000", "Zanos-65", "Zangezur_71", "Zanfan01!", "Za.Nat20", "Zam_1234", "ZakOG&II*70", "zairaKIKIS_920706", "Zaika_3485", "zag.8780_05307N", "#Zafirakis3", "Zadok77*", "Zachispro1!", "zABAR999ABC.", "Zab_0503", "ZA]1RejkO", "_z9fnvpiC", "z90X_#5tba3O4!Ag", "Z8g749kc!!", "Z7zO2b5=mF#31eJT", "Z.61gZGfMh", "Z5w#q7J&", "Z4o1_g6V", "Z4kw#xkBn", "Z4469842@", "Z4311*B0", "Z3_nz92_koz15EJsos250264", "z2YQnw*o", "z21U387OrDs!", "Z1yth2um!", "..Z1y4dAuA9l", "z1UTYBQ_qbytu", "Z1@@urat", "Z!1RsA4J6g9#B8ui", "*Z1317z*", "!Z123456", "Z_100200", "Z082310.", "yzY#UBupU6uNu8", "YzU7U#e2eMABam", "#Yz_u0n!Z94mI25d", "YZa%Usybaha6Y3", "yZ3ndbc*9w$G", "yz14_xT#", "y@YLADYteru8Us", "Y%y@ebEGeWAgA3", "Yya_m#NnR!dhAv24", "&Y&Y7y7y", "$yXYRJ2bzm6FZW*d", "YXy8aZYqA$A9yH", "YXOCV.05ip", "_Yx_b.1199$Bu1.215", "yWy!y@Y4U3YVyP", "Y$$Wpm87", "YWeVE4eBUXuvY$", "yWeH#$712dod", "yvygU7yDa5usu#", "YVUrEMY%eBA8u3", "yvU7yBaqUBAPE$", "yVJI2szg2t%z", "@YVe9uZegYVa#a", "YVB!6aHCce4FgTbp", "YVATU@eLA5u6ys", "yVATUdAHEsu#u5", "Yv487Xw598#", "Y@UWYVY!YtY@U2", "Y$uWeBYPe9u#aQ", "YuVeVlNa4_S", "y!urYte6AgEgyq", "YurijZ-76", "Yura_2010", "yur24-3Gp", "y$UPe@aWE#e3yp", "Yun@l3sc", "Yulya_277237", "YULqbdV5nFj@agh", "yuliaogaJo1!", "Yuli-999", "Yul609!PdwIvfR3_", "Yukon@1992", "Yui-gi-Uhi_Lac_P8090", "y@u%Aqu8esUbUg", "y@u9U4yjUTuZej", "y!U8enADY9AMU8", "y$U6E7EDYsY3eq", "Y%U3E9uSYSEZUb", "@YtYTySeWapY2u", "Ytu#YTE#abuQU4", "YtuMa%E7YBe6as", "Ytn_Gfhjkz_666", "YTKK.IRF1998", "Ytant.ufycr86", "Yt1crf;e", "ySYmYVy6yBUSY#", "ySuYxgX3RmY5.", "YSG7aDQysj53n*vL", "yse@AsujAsY2u2", "ysaSa#Y5U7emed", "@YsaMA7UJA!UnU", "YRY$YmamU4amYt", "YRYNA4ehy!asag", "yRY-Fen-9Nw-sDt", "yruME3UPeLu!EJ", "YrHS9Fn*tVJk", "yrEzejyMe3A#a%", "yReqEBE8ySADA#", "#yratuRaqe4E3E", "@yRAnUGyNU9e9E", "Yran.com1995", "YR1TYM.k", "yQunA4eGu6e5e#", "Yqe#E7e4Egu8uM", "Ype#upYRuSE5ym", "yP8CC*E*Lm", "yp2qc.rG.2Eh", "_YoxtrT3", "You_wan1", "Youtube88.", "Yousei*1", "Your_Guardian_Angel_050813", "Yourelt5!", "young&R10", "you_have_been_hacked_gWSxH1FZfr", "yoSHI88!", "Yorkie_1", "Yopqt.37", "Yomon1998!", "Yogesh@20", "yo32kA9$", "yNYv5J7G*Lwj", "YNyty@e9ELu@uX", "YNy!E7EJuzaDyQ", "YNY6YpAsu7yMu$", "_Ynwalone49", "Y@nk3y!@", "Ynina24.277", "YNeMUhE4a2Y#uv", "$YNE3U8unybUNu", "YNE258subs!#$n", "ync!Jfwm7N", "YnaXy2E7atyPa$", "%YNaVuNyqy8A#y", "yN4*ufZjdo4*OC#U", "yMyvE!Y!YDeVE7", "$ymeqAHe4UbELe", "YMAX@y9mt23", "$YMaQWz2", "yMa2a6U#yhu3az", "YlVwh$ClO@2V", "YLovaksD1a.N", "yLKU*s4tfuTv", "YLK5$cr*", "YLeHUJupY#aWA2", ".YL38Jt#M46xzZ!d", "y!kt4LY1SwnV", "Y@kr@622", "yKD-ojI2", ".ykA9zjtDds3", "Yk8$98bKxdCxp#", "yju$u#yVyBuTu5", "YJqxcXsNHV$2*SmC", "Yjdsq_flhtc12345", "YjA#Y@aLAgEty2", "Yip6z5nfB_9o!2LW", "Y.if544623", "Y.if52520", "...YIDMA819g", "YHYQAVY!aqEHA2", "yhqVZb8*", "^YHN6yhn", "yHESaWUTEsU2E$", "yHe8UQe6eNU!uB", "YhaJu!Y2eWYLAJ", "yH85Bv$a", "=Yh3z#8!C27sbZ4i", "ygw*3sJaH2W8", "YGuXA4AXAjY%at", "YGuJE8y4E6u@Ap", "YgUbYTy5e$ubAm", "YGU6eXyHE4AJu%", "ygU2ETe$AJatys", "YGo3I_QZnz", "Ygl_Bmc6", "Yge$YgUTA8Y7e", "YG_ErQ6ul", "ygeDuWa6y$udY3", "#YGb3_67zM8FA5R0", "Yfnfkmz_30", "Yfnfk.csxrf1505", "Yfnfkb_Z_270781", "Yflt;lf1", "Yflsqrf*1953", "Yfl.irf84", "Yfl.if95", "Yfcnz.2002", "YFCNZ09.05.1996", "YFa6Sd5*4RqK", "y@E#YveXYXa8yH", "Y$EXE9E2a2e2am", "!Yeti37139", "yestV*95ULTq", "yeN-6kA-773-SA6", "Yellow00`", "y%eJUDeZu6ejeR", "%Y$ejEHUDyvy6e", "YehF@aslEy271", "YeHDoOrIy@n72", "YECGAA-55", "y$E%A#E6A9eLuq", "Y$e6a$EdU6agyP", "YDUZU7y3eQeqA#", "YDutU7eqU8a#u7", "yDu$e8ezuQu#Eq", "yDt$uVscU7AM", "Yd#!bcgW6P_Ik9lO", "YdareQYDE8A%AT", "YDAPy2y#epaNym", "yD8dtHV*iKvxjSN", "Y.cz_1234509876", "Ycp.1II5CBDB", "!Ycas1982", "YByXa6uhe#YNEg", "ybWjkU$XMvuYdr4P", "ybULa#U5EgeMUQ", "@ybe4EnEsUXEse", "$ybaqa8U7e7ESE", "y_B4ghKRB", "YAZ.R808X.76RUS", "Yay1nt3rN3ts!2", "y%aWU$E@y9AduP", "YAwn?8sky", "YaTvOyA71521_i", "Yarochka_1991", "Yarkan08-", "y$aRA3Y@YQy3eG", "YAQ731!!", "Yan_Vydysh_22021996", "yankeesTweety_babygurl1", "yankeesseeker_gY9n0", "yankeesRu_G4b9i", "yankeesRomeo-NK1992", "yankeeslennox_1kjxS", "yankeesg%5Fdogg", "yankeesBACHCHUSINGH_95", "Yankees1!", "Yankee.1", "Yana.251010", "Yana.16011998", "Yana07_11_1989", "Yampaw-1", "#y@AMe@uHuTy2u", "Yamaha88!", "Ya@limadad11", ".YaLiin2", "Yaku*6482", "YaKolpak_56", "yA_hdE_r0ytq", "Y#AGAXEDe$U6E#", "#y#aDuPY$UMu5y", "YADAYADA=09=09", "Ya_96clash", "y9Z7JlL!YOA3268d", "y9w6_JPLnI", "Y9umY$YPu#eJY%", "y9R@z46oMNzF!Qy-V99X", "Y9n-8yv-R9T-PWa", "..Y9fVOZiyuO", "Y9E$U2Y3aNE#UD", "y9B0b.1303$Hf.611", "._#y8upN!9qF26fL", "Y8uNa$utASY8av", "Y8s_kO9t3x38lFq", "y8iO.dq41", "Y8EDUqYraJE$UJ", "Y8AtYnuqUZuWA$", "!y8AjEWuveNeqa", "y8A#e#EHA$E7Yz", "y#_8a2S3nupGJdXU", "Y7uvagy5ury$E6", "%Y7EbUPe6YpYLE", "y7aWugadu#U9E7", "!y7aqU3a6u3u$U", "Y78*D3D-W9", "Y6YDeqyMAvy!eX", "y6Y2UvUQEHu#EL", "y6UpaqY$UWEPEL", "Y6LH_vcb", "$Y6emyGYRaVAgU", "$y5yZadaNURE@E", "$y5AJEnU3Ary2a", "#Y5a2eZujE9atE", "y58.Kbn2TKDV", "Y4w-6bG-V5T-HGM", "Y4O!921_eXVpkd73", "_y4IYnS!8ve6", "y4EbAte2a#A8yM", "y4c16pH!508w", "y4aZy$YSU@e8YZ", "Y4aq7pR6m0DNwF_T", "Y3yQypUVE%ytaB", "y3udVp_7K7", "Y3s3C2A0n4$8", "Y2ySATe!U6U2AR", "Y2o*BM5KvTq6", "y2Ay2Ls-", "Y29.08.1998ay", "Y_24_i_3i_4_W_", "!y1asFE67_g0f3jo", "y_138!KoE5Wh9N4q", "Y0zH81gP**", "Y0u8FutUr3&", "XZjyo9i$", "Xzcv@134bn", "Xz10_Mse", "XYZabc98!!", "XypAtujuna2E@a", "Xylo45t!", "xY8MZXLOD!#2Vo_w", "xxZicm58lHcV.", "xxZdpcSus63c.", "xxZ9cJNBd.LG6", "xxZ4BxZyBNSp.", "xxZ3Q.AyC2hck", "xxyx6aeG.mubE", "xxYm3OM.wCIWM", "xxYlPG41W5cA.", "xxyIq.tkp0d3g", "xxyfC5Pifm.9s", "xxYE8fuN5.vAI", "xxY6zzH.Nzcyc", "xxY64py.0QWb6", "xxXvwGX.2W9YA", "xxXNCsyU4.otc", "xxx4nDFWoGKq.", "XXX-303432", "XXX-303431", "XXX-303429", "XXX-299517", "xX.x1996_21", "XXX-1658", "XXX-1496", "-xXx-111", "xxWYXlqUzN7y.", "xxWt.6KLGVqek", "xxwr.acXSDl1M", "xx.W7z1626Aqo", "xxw0sq088bXQ.", "xxvmL1GkHnq.w", "xxVI3J7.hkJY6", "xxV.Hzv.pcTl2", "xxVAqk.61Ufvo", "xxV.7RBlbS6kA", "xxUrT.zMx8DT.", "xxul2h2CPk5.c", "xx.uH7vzegy2U", "xxu2ib.7S2US.", "xxu1kRJN.Uvl6", "xxtq7wYplCL.w", "xxtlasSiiF0N.", "xxT.impy.G0OY", "xxTHdZr59yk.6", "xx.tFzItwzD16", "xxt8gWDBu.THc", "xxt1.YIO3roPc", "xxT1.mV33tHEM", "xxSy4Dy6d1LK.", "xx.sTmXyg.0Bg", "xXsSwW2@", "xxsOc2Ily3i.I", "xxs5rTZ5.7m72", "xxrUI.IWPeJ8g", "xxRKp1Eh4vb3.", "xxRjrXF4VoDr.", "xxrgGIP4.6PoE", "xxRekVihcKU9.", "xxR9aO7XpBCW.", "xxR5F3kSHXrq.", "xxR1zE.YPBLRA", "xxqZYd4oYXoF.", "xxq.k9Q5hO5D2", "xxptR9.NpKMl2", "xxphX2.3pqaD.", "xxPgE393gs54.", "xxPF3p7z.KJHE", "xxpe6TgitPMc.", "xxO.mZQhxU2RI", "xxOIB28K.iR7M", "xxoC9P.RqFE6c", "xxo.8kQYZJVSw", "xxNj4ioyEftT.", "xxn6yqAP0z1F.", "xxN5CZ3Szs.L.", "xxmZwxsRsF9G.", "xxMvDvJ.JaW1w", "xxMJ.8HYv5rwY", "xxMcrBTISq3b.", "xxlvloV3VG.A6", "xxlOtUoHGA51.", "xxlk.Ec7hGQxY", "xxLftHW9NpSt.", "xxLEfsh9St.c.", "xxLDwnq8Fgq2.", "xx.KUD81geugE", "xxKgUWcf9Lhk.", "xxJStp9.WCcac", "xxIy.5hzry9jE", "xxIWF5k.0BH0s", "X_xir1706", "xxINKZuW5B6p.", "xx.iA0ZTGB3ys", "xxHSzRlpN1Uu.", "xxHmhb4R4z29.", "xxhKk4oPUXCK.", "xxHJWo.gc7G8c", "xxHizLp68X6w.", "xXH!ftc954V_s3j0", "xxHEEbh.XsX5g", "xxH3j6Gs.siNI", "xxGl.oO8w3ncQ", "xxGle0cb.4Pzs", "xx.GHMM4PhVUw", "xxG2jtc0ynqr.", "xxfqfXyzTPU2.", "xxfLQ1uC1d8.o", "xxfg6E8C6.26.", "xx.f3WB9Nj5G2", "xxeyP0xCpfep.", "xxEOv0gOu.K2M", "xxeM.0DOLhi1c", "xxe.0jmwxjAUE", "xxDr.DBa7wxjs", "xxDPkiSp4.PCs", "xxdGgF024tUN.", "xxCJtrM.6d10U", "xxbtBfyv.98Ag", "xxb3o.o1RrW66", "xxb1jpF8VoQ.w", "xxAz592tN3ph.", "xxAxtCP.tvKq2", "xxas4e3u3MfN.", "xxaQMev0Mh5.E", "xxAN3Te.Z2b7s", "xxAKpSONU4.s2", "xxAERffkGV1j.", "xxA94ko.4g6vA", "xx.9uBfzmPoqc", "xx.9pOnoSq6jI", "xx9.kqQvq5Yeg", "xx9glNS0COp8.", "xx98h4xq.4LKw", "xx8ypeNnxcC.k", "xx8nh.sqY7ZVI", "xx8m.f5NKHVHs", "xx8D.gmP.8TV.", "xx84pZpu.K7dI", "xx7Ubh3CauhJ.", "xx.7MPoqnnRnw", "xx7.kRT4kGPWg", "xx75qKSSkAxs.", "xx6.xfFiN1Xpg", "xx6vFdR8.62OY", "xx6qU.M0dAS3A", "xx6MOZCdFBn.Q", "xx6k2stIPDuk.", "xx69KofrvAje.", "xx64yo7Gcgz.2", "xx5KuK.i5o3qk", "xx5g4qX.uucgI", "xx5cVu.QjuZaU", "xx51tyFGWH1m.", "xx51nV8.tRfOQ", "xx4Zv9R.7Rvgg", "xx4rrC733Uny.", "xx4ALkby.UlFE", "xx3.zYubklMOY", "xx3WTwHSoN.2I", "xx3Tlma.UtGAc", "xx3jKunBc3LJ.", "xx3bW2U.3VdsM", "xx3a.FTEair3s", "xx2ZcUfpK8Eo.", "xx2XRIo91ddY.", "xx.2bYwYhF9.6", "xx1DXrF.pLGXA", "xx0z.NNO4wUZE", "xWzT8t!F$0", "XWz-MAK-yk5-Dao", "XWW8LEY.", "x!WSm6E0u1l#bT72", "Xwing14-", "XWfEDre9*CFw", "xvtwj*kS2ho8bU$Y", "Xvkal12&%#", "xV9#C5ZHb1l34_2O", "X!tus3nc", "xtrontek-Xinside2", "Xtoccept123.", "_XTItn!7m8Prwv4E", "Xthtgjdtw_2012", "Xthrfcjdf&130385", "X&t%$ffalk1@#", "XSW@xsw2", "xsw2ZAQ!", "Xsw2@wsx", "xsw2!QAZ", "xsw21#eD", "xS7hs9!sk9", "Xro_M1988", "X_reaper1337", "X-rated9992", "X-rated9872", "X-rated9820", "X-rated9557", "X-rated9430", "X-rated9264", "X-rated9096", "X-rated9038", "X-rated8891", "X-rated8744", "X-rated8597", "X-rated8563", "X-rated8531", "X-rated8446", "X-rated8412", "X-rated8202", "X-rated8165", "X-rated7990", "X-rated7886", "X-rated7828", "X-rated7773", "X-rated7748", "X-rated7739", "X-rated7559", "X-rated7487", "X-rated7417", "X-rated7277", "X-rated7200", "X-rated7198", "X-rated7058", "X-rated7019", "X-rated6931", "X-rated6729", "X-rated6719", "X-rated6634", "X-rated6475", "X-rated6390", "X-rated6301", "X-rated6167", "X-rated6092", "X-rated6048", "X-rated5873", "X-rated5865", "X-rated5703", "X-rated5589", "X-rated5366", "X-rated5333", "X-rated5187", "X-rated5108", "X-rated5033", "X-rated4917", "X-rated4844", "X-rated4828", "X-rated4782", "X-rated4778", "X-rated4735", "X-rated4675", "X-rated4402", "X-rated4279", "X-rated4093", "X-rated4073", "X-rated3878", "X-rated3757", "X-rated3635", "X-rated3592", "X-rated3569", "X-rated3521", "X-rated3426", "X-rated3268", "X-rated3182", "X-rated3173", "X-rated3080", "X-rated3031", "X-rated2968", "X-rated2921", "X-rated2597", "X-rated2545", "X-rated2474", "X-rated2419", "X-rated2269", "X-rated2168", "X-rated2164", "X-rated2088", "X-rated2019", "X-rated1986", "X-rated1982", "X-rated1945", "X-rated1928", "X-rated1872", "X-rated1857", "X-rated1837", "X-rated1825", "X-rated1770", "X-rated1503", "X-rated1391", "X-rated1358", "X-rated1143", "X-rated1130", "X-rated1087", "XR8zdZ95bwB$", "XqShzAj$4mov", "Xpy$4asgtmY5", "xpjv0q-3E", "xp5uP.wF3NxQ", "*Xp230036", "Xorula_19831602", "Xo9iso_to6oU", "xO!678kNdl_vB#a1", "XO4z!ay65Tsh9rqE", "Xn.N.7Wx1ffs", "XnB(y3vrMJ5", "_!xmj0RrD2qW", "Xmas200&", "Xm77868!KMX878", "#_XlK!P2705cAFTG", "xk#w65F8v0!bA2Ku", "Xkueswnn1!", "xKeB3UaL9w*2", "$xkAw93Fubpq", "xK7zZ4B$", "Xjqwz*rtC2Jp", "XJE.YAFN2", "XJ28_63y5#1Ze!Na", "XiXAqKl0LtaY.", "XHNhgj8*D4my", "XG_Ubdgbc_666", "xgrHUei$WK53", "Xfqrf_33_", "XFj58bMe*QD@", "X-Files0", "xfcxi6T-B", "XfcqR7*5DEhY", "XF9E$aUMihwK", "Xe%yXaSUNeHy7U", "xE$ujt8nBPYk", "Xerriah31@", "XeNtp4ViZg*H", "Xenien_4096", "XdVTDQ*jR8pG", "!xD3$g^l[", "XD@35x100pr", "xBvc#39!DkWKT0_1", "XBOX_360", "Xbox360!", "Xbnf*61!", "xbfA2rt_b1Su!", "xb$2maQ9", "Xavier_July1", "Xavideus_01", ".Xan.1941.%", "XALIAS_1", "Xalema09?", "x$AHc7U*V23N", "xA_fn_lOt5", "_X9h!AGE7S3w", "X8752c98df91514_", "X7JtUECkTL$q", "x7fOpM4gwD8ZK_!3", "x_7cP51d", "x$79YMjp", "X5$RTkPaL", "X5m10.ZN.6Ds.", "X_5c0p3_X", "x3o8u!7_y2qV", "#x3g48I!0wWy1K_P", "X3$d2JDjWwos", "X3cnI-8Co", "!X2x4357zda#wjD_", "X2Marc&uVw", "X2504_1986", "#X1u6H3ztvl!P_Gd", "X?1cr5tL1308", "X19101992$e", "X@18aSDF", "#X12!gU8Mji_PrlE", "wZ!Yz82skD_#u1V7", "wzuhQ.PEu9Af", "WZhNe-M1z", "Wz8AlJ_Gz", "Wyrmn_25", "WyNznoRZ-GbzQ6Lmw", "w#YNl2izko4DPy_V", "wyCkXWu5$gJQ", "Wya9qyvi.1", "Wxcvbn741852963@", "WXBmDnm5..", "WWWtutBY_190489", "WWW420*69WWW", "WWeezel-WW4344", "wW%&e4w4", "WvzJ6E-sr", "WVUbB10!", "wvT_1954", "WuZa3Y@u2y4Edy", "wuw2D0_o9", "WuVAMy4y%aXe$e", "WUP_475.QSJ", "wU_Nvw3Q", "$WuHibaxJ4Ay", "WUD1988-90", "WU3yta#umyLAry", "W@t^pth0", "wtP4uMuYe.v7", "Wth.th76", "W@terf00d", "W@TER4ELE", "W@tdog1865", "W&TB4UIBB", "@WSX2wsx!QAZ1qaz", "@WSX2wsx", "@WSX1qaz", "WSQ_c9rs", "Wsp1025%", "WsotcoM&53rd", "w=SAFE946", "WRY120_Z4fxLD5", "Wrestle140.5", "Wrath$01", "wr9sm6gyKDk.", "WR7B8N@CXnMk", "WQJk93GwmH$f", "-=WPB=-yankees1", "$wpaHhy3uRt9", "wp_24Hfs", "WOVuk$5jY", "Woud@berg39", "WORTADON.12", "WorldInv@$ion1511", "Worker_05", "Work@100", "WordPass_112", "Wordpass10!", "WordP@$$1", "Wooster427!", "Wombat_1", "Wollbold_23", "Wolf6256!", "Wolf_359", "woiA$cBHUW8k", "$wnUAp8X", "wn.tfgKi7Gaw", "wnr2*yoLc5NXhFuz", "WN*j3owz", "wnHz1!QoAlP8X7_0", "WmT_93aS", "WmP_3863", "wm_104685-3K4767QU", "wLgq$edDS2tF", "wl!_#1hW97eFcLA8", "W!%Jt1Ll", "Wjc23451$", "Wj-260670", "WIP14_SVETA", "_WinxClub743_", "Winter.1", "Winter-1", "Winter09#", "Winter03*", "!Winston1209", "!Winslow123", "Winnie@1", "Winner-88888888", "!Window25", "Win!2014", "Win2003@", "Wilts.68", "Willkell_62", "williamSmart_87", "williamR%3Fbi%5FFredy", "williamnils%5Flennart.", "williamMODEM-1992", "williamgreggy_3eeHr", "williamgeorge_6JYYE", "williamFatPiggy-1983", "~Will5Melvin", "Wiil_7574", "wIg_Bold1", "Wh@tThe69", "$$wHp106", "WH$m9jKsbLCG", "WhJ*fz6oiFx7", "Whisky54-11", "Whatnow1!", "whateverDimmon_007", "whateverBoneman-venus6", "whateverboby00_PQbf1", "WfB_24lS", "weym0.U3", "WeWuMypyWE2y$U", "W#EW#E11", "WeRtH_MaN093", "wer-9zd-p4Z-UDr", "WER28u_1984", "Wep2qk!21", "Welk0m!!", "welcomeshahza_vD4t5", "welcomeSaibe_97", "welcomeLIL_josh_13", "welcomeJK1_5", "welcomehotboy_Vpgs5", "welcomeeduard_7zuxN", "welcomeDeamon_2008", "welcomeCHANGER-7", "welcomeAn_Ev73", "Welcome_5", "WELCOME20-WEKCOME20", "Welcome2015!", "Welcome!2012", "Welcome11!", "Welcome11--", "Welcome1.", "Welcome1!", "Welcome01!", "Welc0meer!c", "weL11209!", "Weitlingstr.41", "Weitlingstr.4", "Weeded55555@@", "WebeQu%ERE$A9u", "WeAre*138*", "weAaQIno0lhLHWsIfL9TQG30ZrI-~B", "we9sYAf7c*bu", "&&wdXWabuSc7&b*QDex_6B*5v?e8V", "WdX36YvgB_0OK", "W!d3n3r781!", "Wd0q#2!QP6z9H=XV", "WCEU_TV15", "WBQew5l_1a#7mLXx", "wb89kU_GYTw8N-8k", "WaZ15378A.", "Waypier51!", "WAyne69!!", "WAwE4A$PAf3d2pu", "Wauchula-316", "*waterS1", "Watermelon-1", "WaTer#BS6", "Waswas@5", "*WASILEK*2580", "Washington1!", "Wash@4718", "#Warrior1", "Warren24!", "!WArr1111", "Wario4life__", "Warhammer!99!", "WALLY1767-WALLY1768", "Walki.12", "Walinoor786.", "WaJ$5D94Prxz", "Waiwai77-3mooxeni", "Wafer_45", "wAD1m_VX", "Wa6A#YhyByta%U", "W_A0x082", "W8sted_r", "W8hlx#Gn", "w*7xuAUS", "w#6!uAMYR1DNZmhc", "W6kMNjroiz-8i2ymy1y4e", "w6$jEyNVn48G", "w6JDb.13298$5F7.4550", "W_6884698", "w5Z9d.19377$sY3.17378", "W5T7G89#", "w%5Fpass", "W_3Bm4St6", "W3Ar3U5!", "W325_N79hJfIi6H#", "w2V6#UNK!f1arl4W", "w2lidZI@DE", "w1nK@454", "_!W1mpAcJ07C", "W1ck3d_s0ng", "W1247!a_6mBK5zfD", "w10.Miwa", "W0wsers!", "!W0S5974_Kwx", "W0lver1ne.1927", "W03$8J0facy4", "vzzx.Lf1", "vZ8&@88*mc", "vz62wKo!_ye", "Vyt_18ktn", "vYsota10.84", "VyPu$U8eQePury", "VYBvyb_8", "VYBMTNuvhp4*", "Vyacheslav123.", "vxF$kFG7", "VWvw471690488.c", "vWqeU_47", "VvF_Lnhk5", "Vuwpei*xqBo3ZFmy", "vu.TOxyyVB9S", "vuJE8Y%ygE8eQa", "vU$ELeDARa7Y!U", "VU9agA#AzaPAXA", "vtT^17ghkK91y62fA", "VTS_5493", "Vtnhj_85", "vtlSVfmdu!53qkQ#", "Vtkmybwf.1", "V.T.H.T.Y._600", "VtD70183Do~1", "VTB_2011", "VT89@UNH93!", "VSV725_5", "vsP$65dhS*Ma", "Vshe_92002", "VSEHmydo%3Apassword", "VSDRVKAV_426", "#VPVNx81SkqM", "VPk18MNP.90", "V!p3r_69", "Voy@ger0", "Vova_2005", "Vova__2001", "VoVa_1986", "Vova1888.05", "Voronin_1991", "VORON_D36", "VORON-02", "VoPR.Fz23", "Voodoo1!", ".VoOdka8", "VOMIRA0*", "VolzhanKa-85", "volodya207-Kitty99", "Volodia-999", "Volodia.1981", "VOINAH_05", "*Voetius-1", "Vo5jPJxH$ZXw", "VNN_7_5_3_7_7_1_9_VNN", "VnJ901ID28_!6c75", "v@N3$$@7374", "!!VMwar33", "VmFIE5V_B", "V.M88996001*", "Vliel@nd02", "Vlctim-1", "Vlasta88-", "Vlad_Nv86", "vladkA@250707", "Vladislav-07", "Vladimir_61_Nik", "Vladimir*1977", "VLADIK25012010@@@", "Vlada_99", "VlAd86_NaDyA86", "Vlad_4321", "VLaD_25610", "Vlad_20061124", "vla_ALX-198", "vko2uK*mGFX5", "Vkn&str1be", "Vkn&str1", "VKizsj6NG*9a", "vKFRL#XleQ4iTfq3", "VkAnan-6!", "vk9.tYNT", "!v_J#zCws9mjI107", "V#jXFPb5_fkh1AHK", "VJQ_VBH99", "VjQ$e5sctXgh" };
}