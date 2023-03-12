using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritma2023
{
    class Program
    {

        static int asalRec(int sayi, int mod)
        {
            if (sayi < 2) return 0;

            if (sayi % mod == 1) Console.WriteLine("asal"); ;
            if (mod * mod > sayi) Console.WriteLine("asal"); ;

            return asalRec(sayi, mod + 1);
        }


        static int paraRecursive(int[] para, int elemanSay, int toplam)
        {
            if (toplam == 0) return 1;
            if (toplam < 0) return 0;
            if (elemanSay <= 0 && toplam >= 1) return 0;
            return paraRecursive(para, elemanSay - 1, toplam) + paraRecursive(para, elemanSay, para[elemanSay - 1]);
        }

        static int ugly(int sayi, int bolum)
        {
            while (sayi % bolum == 0)
            {
                sayi = sayi / bolum;
            }
            return sayi;
        }

        //------------------------------- VİZE ÖNCESİ Mİ SONRASI MI HATIRLAMIYORUM--------------------------------------------------------------------------

        class Btree
        {
            public int data;
            public int ch;
            public string huffman;
            public Btree left;
            public Btree right;
        }

        static int max(int a, int b)
        {
            return a > b ? a : b;
        }
        static string[] hash = new string[32];
        static int[] karakter = new int[255];
        static string[] huf = new string[255];

        static int knapSack(int[] deger, int[] agırlık, int c, int kapasite)
        {
            if (kapasite <= 0) return 0;
            if (c == -1) return 0;
            if (kapasite < agırlık[c]) return knapSack(deger, agırlık, c - 1, kapasite);

            else
                return max(knapSack(deger, agırlık, c - 1, kapasite), deger[c] + knapSack(deger, agırlık, c - 1, kapasite - agırlık[c]));



        }
        static bool reverse(string hf, string kontrol)
        {
            bool f = true;
            for (int i = 0; i < hf.Length && i < kontrol.Length; i++)
            {
                if (hf[i] != kontrol[i]) { f = false; break; }
            }
            return f;

        }

        static bool kontrol(int[,] x)
        {
            int t1 = 0;
            int t2 = 0;
            bool hata = true;

            for (int i = 0; i < 8; i++)
            {
                t1 = 0;
                t2 = 0;
                for (int j = 0; j < 8; j++)
                {
                    t1 += x[i, j];
                    t2 += x[j, i];
                }
                if (t1 > 1) hata = false;
                if (t2 > 1) hata = false;

            }//satır ve sütun toplamı
            int length = 8;
            for (int i = 0; i < length; i++)
            {
                t1 = 0;
                int satır = 0;
                t1 = 0;
                for (int j = i; j >= 0; j--)
                {
                    t1 = x[j, satır];
                    satır++;
                }
                if (t1 > 1) hata = false;
            }
            for (int i = 1; i < length; i++)
            {
                int satır = i;
                t1 = 0;
                for (int j = 7; j >= 0; j--)
                {
                    if (satır <= 7) t1 += x[satır, j];
                }
                if (t1 > 1) hata = false;
            }
            t2 = 0;
            for (int i = 0; i < length; i++)
            {
                int satır = 0;
                t2 = 0;
                for (int j = i; j < 8; j++)
                {
                    t2 += x[satır, j];
                    satır++;
                }
                if (t2 > 1) hata = false;

            }
            for (int i = 0; i < length; i++)
            {
                int satır = 0;
                t2 = 0;
                for (int j = i; j < length; j++)
                {
                    t2 += x[j, satır];
                    satır++;
                }
                if (t2 > 1) hata = false;
            }

            return hata;

        }
        static void yaz(int[,] x)
        {
            int length = 8;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write("{0} ", x[i, j]);
                }
                Console.WriteLine();
            }
        }

        static int hf(string text)
        {
            int toplam = 0;
            for (int i = 0; i < text.Length; i++)
            {
                toplam += (byte)text[i];
            }

            return toplam & 0x1f;
            //return toplam % hash.Length;

        }

        static void hInsert(string text)
        {

            // dolu ise boş yer aranacak
            int indis = hf(text);
            if (hash[indis] == "") hash[hf(text)] = text;
            else
            {   //  8..31
                //int j = 0;
                //while(j<hash.Length)
                //{
                //    indis++;
                //    indis = (indis % hash.Length);
                //    if (hash[indis] == "") { hash[indis] = text; break; }

                //    j++;
                //}


                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] == "") { hash[i] = text; break; }
                }
            }

        }


        static bool hashSearch(string text)
        {

            // return hash[hf(text)] == text ? true : false;
            int indis = hf(text);

            if (hash[indis] == text) return true;
            else
            {
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] == text) return true;
                }
            }

            return false;
        }
        static Btree local(Btree a, Btree b)
        {
            Btree bt = new Btree();
            bt.data = a.data + b.data;
            bt.left = a;
            bt.right = b;
            return bt;

        }
        static void tree(Btree[] bt)
        {
            if (bt[1] == null) return;

            bt[0] = local(bt[0], bt[1]);
            bt[1] = null;
            Array.Sort(bt, (object x, object y) =>
            {
                int a = 0;


                if (x == null && y == null) return 0;
                if (x == null) return 1;
                if (y == null) return -1;
                if (((Btree)x).data < ((Btree)y).data) a = -1;
                if (((Btree)x).data > ((Btree)y).data) a = 1;
                return a;
            });
            tree(bt);

        }
        static void yazBtree(Btree bt, string yön)
        {
            if (bt == null) return;
            if (bt.left == null)
            {
                bt.huffman = yön;
                karakter[bt.ch] = bt.ch;
                huf[bt.ch] = yön;
            }
            yazBtree(bt.left, yön + "0");
            if (bt.right == null) bt.huffman = yön;
            yazBtree(bt.right, yön + "1");

        }

        static void yazBtreeSonuc(Btree bt)
        {
            if (bt == null) return;
            if (bt.left == null) Console.WriteLine("{0}    {1}", (char)bt.ch, bt.huffman);
            yazBtreeSonuc(bt.left);
            yazBtreeSonuc(bt.right);



        }
        static void hashInsertNode(string text)
        {
            /* hashlnk n = new hashlnk();
             n.text = text;
             n.prev = null; n.next = null;

             int indis = hf(text);
             if (hashNode[indis] == null) hashNode[indis] = n;
             else
             {
                 hashlnk t = hashNode[indis];

                 //  bloğun son bloğunu bulacağız
                 while (t.next != null) t = t.next;
                 t.next = n;
                 n.prev = t;*/
        }

        static bool hashSearchNode(string text)
        {
            /* int indis = hf(text);
             if (hashNode[indis] == null) return false;
             hashlnk temp = hashNode[indis];

             bool bulundu = false;
             while (temp != null)
             {
                 if (temp.text == text) { bulundu = true; break; }
                 temp = temp.next;
             }*/
            return false;
            //bulundu ;
        }
        static void hashDelete(string text)
        {
            int indis = hf(text);
            if (hash[hf(text)] == text) hash[hf(text)] = "";
            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[indis] == text) { hash[hf(text)] = ""; break; }
            }

        }
        static void Main(string[] args)
        {

            #region Karantina Haftası resimn içine string saklama
            /*
             //strningin bitlerini image in içerisine pikselin en küçük seviyeli bitine string in en küçük seviyeli bitini yaz
             string st = "Merhaba";


             byte[] arr = new byte[1000];
             int index = 0;
             st = (byte)st.Length + st;
             //st.Length --> bu 8 bit dizinin ilk 8 byte'ının en düşük seviyeli bitlerine
             //
             for (int i = 0; i < st.Length; i++)//her harfi sırayla al
             {
                 byte ch = (byte)st[i]; //harfleri alır

                 for (int j = 0; j < 8; j++)//8 er bite ayır
                 {
                     if ((ch & 1) == 1) arr[index] = (byte)(arr[index] | 1);

                     else arr[index] = (byte)(arr[index] & 0xfe);

                     if ((ch & 1) == 1) Console.Write("1");

                     else Console.Write("0");

                     index++;

                     ch >>= 1;
                 }
             }
             
            #endregion

            #region Karantina Haftası  

            byte w = 1;
            index = 0;
            Console.WriteLine();
            
            for (int i = 0; i < 7; i++)
            {
                byte ch = 0;
                w = 0x1;
                for (int j = 0; j < 8; j++)
                {
                    if ((arr[index] & 1) != 0) ch = (byte)(ch | w);


                    if ((arr[index] & 1) != 0) Console.Write("1");

                    else Console.Write("0");

                    index++;
                    w <<= 1;
                }
                Console.WriteLine((char)ch);
                
            }
               
            */
            #endregion

            #region Substring

            /*
             int[] cluster = { 1, 2, 3, 4 }; //Alt küme sayısı (2^n)-1 --> 2^4 - 1=15
             for (int i = 1; i < 16; i++)
             {
                 int mask = 1;
                 for (int j = 0; j < 8; j++)
                 {
                     if ((i&mask)!=0)
                     {
                         Console.Write(cluster[j]);
                     }
                     mask <<= 1;
                 }
                 Console.WriteLine();
             }
            */

            #endregion

            #region 100 elemanlı bir dizinin alt kümeleri && toplamları 500 olan alt küme sayısı !!Sakın Çalıştırma 2^100
            /*
            int[] cluster = new int[5];
            int[] array = new int[6];
            int index = 0;
            int sum = 0;
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                cluster[i] = i + 1;
            }
            while (array[5] != 1)
            {
                array[index]++;
                while (array[index] == 2)
                {
                    array[index] = 0;
                    index++;
                    array[index]++;
                }
                for (int i = 0; i < 5; i++)
                {
                    if (array[i] == 1) Console.WriteLine(cluster[i]); //toplam+=cluster[i]; -->toplamları 50 olanı bulmak için
                }

                if (sum == 15) count++;

                index = 0;
            }*/
            #endregion

            #region Bir string içerisinde en çok kullanılan harfi bulma
            /*
            string st = "sjddfnjsfdjjdddjjfjddd";
            //string s = "abcdefghijklmnouprsxyz";
            int[] sLength = new int[50];
            int enB = 0;
            int enB2 = 0;
            for (int i = 0; i < st.Length; i++)
            {
                sLength[st[i] - (byte)'a']++;

                if (sLength[st[i] - (byte)'a'] > enB)
                {
                    enB = sLength[st[i] - (byte)'a'];
                }
                enB2 = sLength[st[i] - (byte)'a'];
                if (enB > enB2)
                {
                    enB2 = sLength[st[i] - (byte)'a'];
                }

            }
            Console.WriteLine(enB2);*/


            #endregion

            #region s2, s1 in içerisinde varmı Doğru olmayan çözüm 
            /*
            string s1 = "dfsdfhadssd";
            string s2 = "sd";


            for (int i = 0; i < s1.Length - s2.Length; i++)
            {
                int count = 0;

                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i + j] == s2[j])  count++; 
                }

                if (count == s2.Length) Console.WriteLine("Find");

               
            }




            
            */

            #endregion

            #region s2, s1 in içerisinde varmı Daha kısa çözüm 
            /*
            string s1 = "bilgisayar";
            string s2 = "bilgi";

            for (int i = 0; i < s1.Length - s2.Length; i++)
            {

                int sayac = 0;
                while (s1[i + sayac] == s2[sayac])
                {
                    sayac++;


                    if (sayac == s2.Length) break;

                }
                if (sayac == s2.Length) Console.WriteLine("find");
            }


            // else Console.WriteLine("not find");

            */
            #endregion

            #region 00110101010111111 --> 11 alt string yakala (otomatadaki gibi statelerle çözüm)
            /*
            string st = "236111853987";
            //string st2 = "101010101110";
            int state = 0;

            for (int i = 0; i < st.Length; i++)
            {

                if (state == 0)
                {
                    if (st[i] == '1') { state = 1; continue; }
                }
                if (state == 1)
                {
                    if (st[i] == '1') { state = 2; continue; }
                }
                if (state == 2)
                {
                    if (st[i] == '1') { state = 3; }
                }



               

            }
            if (state == 3) Console.WriteLine("find");
            */
            #endregion

            #region bir önceki sorunun daha iyisi (11 yakalama)
            /*
            string st = "10101010110";
            int[,] q = new int[3, 2];
            
            int state = 0;

            q[0, 0] = 0; //0. state 0 gelirse 0.state e geç
            q[0, 1] = 1; //0. state 1 gelirse 1.state e geç
            q[1, 0] = 0; //1. state 0 gelirse 0.state e geç
            q[1, 1] = 2; //1. state 1 gelirse 2.state e geç
            q[2, 0] = 2; //1. state 1 gelirse 2.state e geç
            q[2, 1] = 2; //2. state 1 gelirse 2.state e geç
            for (int i = 0; i < st.Length; i++)
            {
                state = q[state, st[i] - (byte)'0'];
            }
            if (state == 2) Console.WriteLine("find");
            
            */
            #endregion

            #region bir önceki sorunun harflisi (sd yakalama)
            /*
            string st = "jklhoprylgsdab";
            int[,] q = new int[3, 50];
            int state = 0;
           

            q[0, (byte)'s' - (byte)'a'] = 1;

            q[1, (byte)'d' - (byte)'a'] = 2;
            q[1, (byte)'s' - (byte)'a'] = 1;

            
            for (int i = 0; i < 50; i++)
            {
                q[2, i] = 2;
            }

            for (int i = 0; i < st.Length; i++)
            {
                state = q[state, st[i] - (byte)'a'];
            }
            if (state == 2) Console.WriteLine("find");*/
            #endregion

            #region abc bulma kendim yazdım doğru olmayabilir
            /*
            string st = "gkgabckghjytc";
            int[,] q = new int[4, 50];
            int state = 0;

            q[0, (byte)'a' - (byte)'a'] = 1;
           
            q[1, (byte)'b' - (byte)'a'] = 2;
            q[1, (byte)'a' - (byte)'a'] = 1;
           
            q[2, (byte)'c' - (byte)'a'] = 3;
            q[2, (byte)'b' - (byte)'a'] = 1;
            q[2, (byte)'a' - (byte)'a'] = 2;

            for (int i = 0; i < 50; i++)
            {
                q[2, i] = 2;
            }

            for (int i = 0; i < st.Length; i++)
            {
                state = q[state, st[i] - (byte)'a'];
            }
            if (state == 2) Console.WriteLine("find");


            */
            #endregion

            #region ÖDEV OLABİLİR
            //ÖDEV OLABİLİR
            //ab den sonra cd veya nm kabul eden
            //  sdfgfabcdjklj           kklkdabnmkkop
            /*
            string st = "abcd" ;
            int[,] q = new int[6,50];
            int state = 0;
            q[0, (byte)'a' - (byte)'a'] = 1;
            q[0, (byte)'b' - (byte)'a'] = 0;
            q[0, (byte)'c' - (byte)'a'] = 0;
            q[0, (byte)'d' - (byte)'a'] = 0;
            q[0, (byte)'n' - (byte)'a'] = 0;
            q[0, (byte)'m' - (byte)'a'] = 0;
         
            q[1, (byte)'b' - (byte)'a'] = 2;
            q[1, (byte)'a' - (byte)'a'] = 0;
            q[1, (byte)'c' - (byte)'a'] = 0;
            q[1, (byte)'d' - (byte)'a'] = 0;
            q[1, (byte)'n' - (byte)'a'] = 0;
            q[1, (byte)'m' - (byte)'a'] = 0;

            q[2, (byte)'c' - (byte)'a'] = 3;
            q[2, (byte)'a' - (byte)'a'] = 0;
            q[2, (byte)'b' - (byte)'a'] = 0;
            q[2, (byte)'d' - (byte)'a'] = 0;
            q[2, (byte)'n' - (byte)'a'] = 5;
            q[2, (byte)'m' - (byte)'a'] = 0;

            q[3, (byte)'d' - (byte)'a'] = 4;
            q[3, (byte)'a' - (byte)'a'] = 0;
            q[3, (byte)'b' - (byte)'a'] = 0;
            q[3, (byte)'c' - (byte)'a'] = 0;
            q[3, (byte)'n' - (byte)'a'] = 0;
            q[3, (byte)'m' - (byte)'a'] = 0;

            q[4, (byte)'n' - (byte)'a'] = 4;
            q[4, (byte)'a' - (byte)'a'] = 4;
            q[4, (byte)'b' - (byte)'a'] = 4;
            q[4, (byte)'m' - (byte)'a'] = 4;
            q[4, (byte)'c' - (byte)'a'] = 4;
            q[4, (byte)'d' - (byte)'a'] = 4;

            q[5, (byte)'m' - (byte)'a'] = 4;
            q[5, (byte)'a' - (byte)'a'] = 0;
            q[5, (byte)'b' - (byte)'a'] = 0;
            q[5, (byte)'m' - (byte)'a'] = 0;
            q[5, (byte)'c' - (byte)'a'] = 0;
            q[5, (byte)'d' - (byte)'a'] = 0;

             for (int i = 0; i < 50; i++)
            {
                q[5, i] = 5;
            }

            for (int i = 0; i < st.Length; i++)
            {
                state = q[state, st[i] - (byte)'a'];
            }
            if (state == 4) Console.WriteLine("find");//final state
            */
            #endregion

            #region ÖDEV OLABİLİR2
            //101010101010....   sürekli gelen 1 ve 0 lar var
            //mod 4 e göre kalan 1leri belirle


            #endregion

            #region pi sayısı bulma

            /*
            //pi=4(1-1/3+1/5-1/7+1/9....)

            double pi = 1;
            int t = -1;

            for (int i = 3; i < 100; i+=2)
            {
                pi =pi+ (double)1 / i * t;
                t = t * -1;


            }
            Console.WriteLine(pi * 4);
            */
            #endregion
            #region pi sayısı 2
            //pi=3+4/(2*3*4)-4/(4*5*6)+4/(6*7*8)....
            /*
            double pi = 3;
            int t = 1;

            for (int i = 2; i < 100; i++)
            {
                pi = pi + (double)4 / (i * (i + 1) * (i + 2))*t;
                t *= -1;
            }
            Console.WriteLine(pi);*/
            #endregion

            #region asal sayı bulma
            /*
            int n =39;
            bool asal = true;

            for (int i = 2; i < Math.Pow(n, 0.5); i++)
            {
                if (n % i == 0)
                {
                    asal = false; 
                    break;
                }
            }
            if (asal) Console.WriteLine("Asal");
            else Console.WriteLine("Asal değil");
            */
            #endregion

            #region longest common substring
            /*
            string s1 = "abcdefg";
            string s2 = "abkdefg";

            int[,] dizi = new int[s1.Length, s2.Length];
            int enBuyukSubString = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {

                    if (s1[i] == s2[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            dizi[i, j] = 1;
                        }
                        else
                        {
                            dizi[i, j] = dizi[i - 1, j - 1] + 1;
                            
                            if (enBuyukSubString < dizi[i, j])
                            {
                                enBuyukSubString = dizi[i, j];
                            }
                        }
                       

                    }
                    else
                    {
                        if (i == 0 || j == 0)
                        {
                            dizi[i, j] = 0;
                        }
                        else
                        {
                            Math.Max(dizi[i - 1, j], dizi[i, j - 1]);
                        }

                        

                    }
                }
            }
            Console.WriteLine(enBuyukSubString);
            */
            #endregion



            #region  32 bitlik sayıyı rotate edelim
            //Rotate shift yapıldığında taşma yapan yani kaybolan sondaki bitin başta yerini alması
            /*
            uint a = 0xffffffff;
            uint b = 0x80000000;

            for (int i = 0; i < 32; i++)
            {
                if ((a&b)!=0)
                {
                    a = a << 1;
                    a++;
                }
                else
                {
                    a = a << 1;
                }
            }
            Console.WriteLine(Convert.ToString(a,toBase:2));*/
            #endregion

            #region 0'ları 1 ; 1'leri 0 yapalım
            /*
            uint a = 0xffffffff;
            uint b = 1;
            uint c = 0xfffffffe;
            uint d = 0x00000001;

            Console.WriteLine(a);

            for (int i = 0; i < 32; i++)
            {
                if ((a & b) != 0) a = a & c;

                else a = a | d;

                b <<= 1;
                c <<= 1;
                c++;
                d <<= 1;
            }
            Console.WriteLine(a);
            */
            #endregion

            #region  A sayısının bütün bitlerini b sayısına aktaralım
            /*
            uint a = 0xfefefefe;
            uint b = 546545545;
            uint mask = 1;

            b = 0; // b'yi a'yı kopyalayabilmek için boşalttık 

            for (int i = 0; i < 32; i++)
            {
                if ((a & mask) != 0) b = b | mask;

                mask <<= 1;
            }
            Console.WriteLine(a);
            Console.WriteLine(b);
            */
            #endregion

            #region  En yüksek seviyeli 5 biti 1 artıralım (eksik)
            /*
            uint a = 0xffffffff;
            uint b = 0xf8000000;
            b = b + 0x08000000;
            Console.WriteLine(a);
            a = a | b;
            Console.WriteLine(a);
            Console.WriteLine(Convert.ToString(a, toBase: 2));
            Console.WriteLine(Convert.ToString(b, toBase: 2));
            */
            #endregion

            #region   En yüksek seviyeli 5 bit ile en düşük seviyeli 5 biti toplayalım
            /*
            uint a = 0xf800001f;
            uint b = 0x00000001f;
            b = b << 28;
            a = a + b;
            Console.WriteLine(Convert.ToString(a, toBase: 2));
            */
            #endregion

            #region En yüksek seviyeli 4 bit ile 13,14,15 ve 16.bitler yeni bir sayı oluşturuyor bu sayıyı bir artırınız
            /*
            uint a = 0xf000f000;
            uint b = 0x0fffffff;
            uint c = a | b;
            c >>= 28;
            c <<= 20;
            a <<= 4;
            uint d = a | c;
            d >>= 16;
            d++;

            Console.WriteLine(Convert.ToString(d,toBase:2));
            Console.WriteLine(d);


            */
            #endregion


            #region 128 bitlik bir sayı oluşturunuz ve 1 artırınız
            /*
            uint d1 = 0, d2 = 0, d3 = 0, d4 = 0;

            uint h = d4;
            d4++;
            if (h > d4)
            {
                h = d3;
                d3++;
            }
            else if (h > d3)
            {
                h = d2;
                d2++;
            }
            else if (h > d2)
            {
                h = d1;
                d1++;
            }

            Console.WriteLine(h);*/
            #endregion

            #region  32 bitlik bir sayının bir işlem sonucu taşma biti olup olmadığını bulunuz

            /*
            uint a = 0xfffffff;
            int t = (int)a;
            uint b = 1;
            a = a + b;

            if (t == a - b) Console.WriteLine("yok");
            else Console.WriteLine("var");

            */
            //------------------------------------------------------------------------
            //bu çözüm iş yapar ancak sayıyı int tutmadan da çözüm bulabiliriz
            /*
            uint a = 0xffffffff;
            uint b = 1;
            uint d = a & 0x80000000;
            uint e = b & 0x80000000;
            d >>= 30;
            e >>= 30;
            d = d + e;
            a = a + b;
            uint f = a & 0x80000000;
            f >>= 30;
            if ((f + e) == d) { Console.WriteLine("yok"); }
            else { Console.WriteLine("var"); }

            */
            //------------------------------------------------------------------------
            //bir başka çözümde şu şekilde olabilir

            /*
            uint a = 0xffffffff;
            uint b = 1;
            uint h = a;
            a = a + b;
            if (h > a) { Console.WriteLine("var"); }
            else { Console.WriteLine("yok"); }
            */











            #endregion

            #region      int bir sayıyı string yazdırınız

            /*
            int a = 15902468;
            string[] X = { " SIFIR ", " BİR ", " İKİ ", " ÜÇ ", " DÖRT ", " BEŞ ", " ALTI ", " YEDİ ", " SEKİZ ", " DOKUZ " };

            string b = "";
            while (a>0)
            {
                int c = a - (a / 10) * 10;
                b = X[c] + b;
                a = a / 10;
            }

            Console.WriteLine(b);
            */
            #endregion




            #region    string bir sayıyı int yazdırınız
            /*
            string a = "123";

            uint b = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int c = a[i] - (byte)'0';
                b = b * 10 + (uint)c;
            }
            Console.WriteLine(b);

            */
            #endregion

            #region recursive Asal

            //Console.WriteLine(asalRec(8,2));
            #endregion

            #region 11 den hemen sonra 00 gelmeli
            /*
            //0101100

            string s1 = "0101010101100";

            int[,] q = new int[5,2];

            // q0--->1----->q1---->1------>q2---->0----->q3------>0----->q4

            q[0, 0] = 0; 
            q[0, 1] = 1; //0. state'ten 1. state'e geçiş

            q[1, 0] = 0; 
            q[1, 1] = 2; //1. state'ten 2. state'e geçiş

            q[2, 0] = 3;
            q[2, 1] = 0; 

            q[3, 0] = 4;
            q[3, 1] = 0;

            q[4, 0] = 4;
            q[4, 1] = 4;


            int state = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                state = q[state, s1[i] - (byte)'0'];
            }

            if (state == 4) Console.WriteLine("bulundu");
            
            */


            #endregion

            #region 11 den sonra 00 ya da 10 gelen
            /*
            //q0--->1----->q1---->1------>q2---->0----->q3------>0----->q4
            //                             | 1------->q5--->0----->q4

            string s1 = "0101010101110";

            int[,] q = new int[6, 2];



            q[0, 0] = 0;
            q[0, 1] = 1; //0. state'ten 1. state'e geçiş

            q[1, 0] = 0;
            q[1, 1] = 2; //1. state'ten 2. state'e geçiş

            q[2, 0] = 3;
            q[2, 1] = 5;

            q[3, 0] = 4;
            q[3, 1] = 0;

            q[4, 0] = 4;
            q[4, 1] = 4;

            q[5, 0] = 4;
            q[5, 1] = 0;


            int state = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                state = q[state, s1[i] - (byte)'0'];
            }
            if (state == 4) Console.WriteLine("bulundu");

            */

            #endregion


            #region aa dan sonra ya b ya da cb gelecek
            /*
            //alfabe a,b,c

            //q0-->a--->q1--->a--->q2---->b--->q3
            //                        --->c--->q4--->b--->q3

            string s1 = "bcaacb";
           
            int[,] q = new int[5, 3];

            q[0,(byte)'a'-(byte)'a']=1;
            q[0,(byte)'b'-(byte)'a']=0;
            q[0,(byte)'c'-(byte)'a']=0;

            q[1,(byte)'a'-(byte)'a']=2;
            q[1,(byte)'b'-(byte)'a']=0;
            q[1,(byte)'c'-(byte)'a']=0;

            q[2,(byte)'a'-(byte)'a']=0;
            q[2,(byte)'b'-(byte)'a']=3;
            q[2,(byte)'c'-(byte)'a']=4;

            q[3,(byte)'a'-(byte)'a']=3;
            q[3,(byte)'b'-(byte)'a']=3;
            q[3,(byte)'c'-(byte)'a']=3;

            q[4,(byte)'a'-(byte)'a']=0;
            q[4,(byte)'b'-(byte)'a']=3;
            q[4,(byte)'c'-(byte)'a']=0;

            int state = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                state = q[state, s1[i] - (byte)'a'];
               if (state == 3) break;
            }
            if (state == 3) Console.WriteLine("bulundu");

            else
            {
                Console.WriteLine("bulunmadı");
            }*/
            #endregion

            #region 010101010101111001010.... sınırsız veri geliyor mod 5 e göre kalan 2 olan
            //state ile çöz 1111111 0000000 ya da 11 00
            //              7 tane 1 ve 0  yanyana olacak şekilde ya da 2 tane 1 ve 0 yanyana

            /* 
            int s1 = 10110;

            int[] dizi = new int[20];

            int dec_s1 = 0;
            int base1 = 1;
            for (int i = 0; i < 20; i++)
            {
                int last_digit = s1 % 10;
                s1 = s1 / 10;

                dec_s1 += last_digit * base1;
                base1 *= 2;

               
            }
            if (dec_s1 % 5 == 2)
            {
                Console.WriteLine(dec_s1);
            }
            
         */

            #endregion

            #region 8 elemanlı bir dizinin alt küme elemanlarını gösterme

            /*
            int n = 7;
            int[] dizi = new int[n + 1];
            int[] kume = { 12, 32, 45, 67, 78, 45, 23, 65 };
            while (dizi[n] != 1)
            {
                for (int i = 0; i < n; i++)
                {
                    if (dizi[i] == 1) Console.Write(kume[i] + " ");
                }

                Console.WriteLine();
                dizi[0]++;
                for (int i = 0; i < n; i++)
                {
                    if (dizi[i] == 2) {dizi[i] = 0; dizi[i + 1]++;}
                }
            }
            */
            #endregion

            #region 5 elemanlı bir kümenin alt kümeleri ve toplamları 5 olanları yazdıran BitWise
            /*
            for (int i = 0; i < 32; i++)
            {
                int k = 1;
                int toplam = 0;
                for (int j = 0; j < 5; j++)
                {
                    if ((i & k) != 0) { Console.Write(j + ""); toplam += j; }
                    k <<= 1;
                }
                Console.WriteLine();
                if (toplam == 5) Console.WriteLine("Toplam"+toplam);

                //Console.WriteLine("satır sayısı"+i);


            }

            */

            #endregion

            #region bozuk para sorusu 3 farklı bozuk para var 1 2 3 toplamları 4 olan n farklı
            /*
            int[] para = { 1, 2, 3 ,4};
            int toplam = 4; //1+1+1+1 1+1+2  1+3 2+2 4 

            int[] tablo = new int[5];
            tablo[0] = 1;
            for (int i = 0; i < para.Length; i++)
            {
                for (int j = para[i]; j <=toplam; j++)
                {
                    tablo[j] += tablo[j - para[i]];
                }
            }
            Console.WriteLine(tablo[toplam]);


            */
            #endregion

            #region bozuk para sorusu RECURSİVE (stack over flow hatası veriyor)
            /*
            int[] para = { 1, 2, 3 };
            Console.WriteLine(paraRecursive(para,3,4));*/
            #endregion

            #region ilk 1000 asal sayıları dizi ile bulma
            /*
            int[] asal = new int[1000];
            for (int i = 2; i < 1000; i++)
            {
                asal[i] = i;
            }
            for (int i = 0; i <= Math.Pow(1000, 0.5); i++)
            {
                if (asal[i] != 0)
                {
                    for (int j = 0; j < 1000; j++)
                    {

                        asal[j] = 0;

                    }
                }

                Console.WriteLine(asal[i]);

            }

            */

            #endregion

            #region ugly sayı 2 3 5 in katları olacak sayılar
            /*
            int sayi = 0;

            for (int i = 2; i < 100; i++)
            {
                sayi = ugly(i, 2);
                sayi = ugly(sayi, 3);
                sayi = ugly(sayi, 5);
                if (sayi == 1) Console.WriteLine(i);
            }*/
            #endregion


            #region matrisi tersine çevirme döndürme
            /*
            int[,] matris = { {1, 2, 3 },
                              {4, 5, 6 },
                              {7, 8, 9 }};
            
            for (int i = 2; i >= 0; i--)
            {
                for (int j = 2; j >= 0; j--)
                {
                    Console.WriteLine(matris[i,j]);
                }
                Console.WriteLine();
            }
            */

            #endregion

            #region matrisi 90 derece döndürme
            /*
            int[,] matris = { {1, 2, 3 },
                              {4, 5, 6 },
                              {7, 8, 9 }};


            */
            #endregion




            #region 100 elemanlı int tipindeki x,y dizisilerinin içinde artan(sıralı) değerler vardır bu iki dizinin elemanlarını z dizisine sıralanmış şekilde aktar

            /*
            int[] x = { 2, 3, 5, 6 };
            int[] y = { 1, 7, 8, 9 };
            int[] z = new int[8];

            int i = 0, j = 0,k=0;
            while (i<x.Length && j<y.Length)
            {
                if (x[i]<y[j])
                {
                    z[k++] = x[i++];
                }
                else
                {
                    z[k++] = y[j++];
                }
            }

            while (i < x.Length)
                z[k++] = x[i++];

           
            while (j < y.Length)
                z[k++] = y[j++];


            for (int l = 0; l < z.Length; l++)
            {
                Console.WriteLine(z[l]);
            }

           
            */
            #endregion

            #region 1000 elamanlı bir diziyi 10*10*10 luk başka bir diziye aktar
            /*
            int[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[,,] y = new int[2, 2, 2];  //{ {{1, 2}, {3, 4}},
                                           //  {{5, 6}, {7, 8}}  }

            int a = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        y[i, j, k] = x[a++];
                    }
                }
            }

            for (int k = 0; k < 2; k++)
            {
                for (int l = 0; l < 2; l++)
                {
                    for (int m = 0; m < 2; m++)
                    {
                        Console.WriteLine(y[k, l, m]);
                    }
                }
            }

            */
            //----------------------------------------------------------------------
            /*
             for (int i = 0; i < 2; i++)
             {
                 y[0,0, i] = x[a++]; // {0,0,0},{0,0,1}
             }

             for (int i = 0; i < 2; i++)
             {
                 y[0, 1, i] = x[a++]; //{0,1,0},{0,1,1}
             }

             for (int i = 0; i < 2; i++)
             {
                 y[1, 0, i] = x[a++]; //{1,0,0},{1,0,1}
             }

             for (int i = 0; i < 2; i++)
             {
                 y[1, 1, i] = x[a++]; //{1,1,0},{1,1,1}
             }
            */








            #endregion

            #region x ve y değişkenlerindeki en uzun ortak bit yapısı
            /*
            int s1 = 1010101;
            int s2 = 1010101;

            */
            #endregion

            #region bitwise tek çift bulma
            /*
            int n = 101;

            Console.WriteLine((n&1)!=1 ? "çift" : "tek");

            */
            #endregion

            #region bitwise aynı olan bit'in numarası

            /*
            int sayac = 1;
            int a = 16; //10000
            int b = 7;  //00111 //4.bitleri aynı


            while (a>0||b>0)
            {
                bool n = a % 2 == 1;
                bool m = b % 2 == 1;


                if (!(n ^ m)) break;
                a >>= 1;
                b >>= 1;
                sayac++;
            }
            Console.WriteLine(sayac);


            */
            #endregion



            #region N vezir problemi

            /*
            static int[,] tahta = new int[8, 8];
            static int kosegen(int a, int b, int yon)
            {
                int adt = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (yon == 1)

                    {
                        if ((a + i) > 7) break;
                        if ((b + i) > 7) break;
                        adt += tahta[a + i, b + i];
                    }

                    else
                    {
                        if (b - i < 0) break;
                        if ((a + i) > 7) break;
                        adt += tahta[a + i, b - i];
                    }
                }

                return adt;
            }
            static int kontrol()
            {
                int satir = 0;
                int sutun = 0;
                for (int i = 0; i < 8; i++)
                {
                    satir = 0;
                    sutun = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        satir += tahta[i, j];
                        sutun += tahta[j, i];
                    }
                    if (satir > 1) return 1;
                    if (sutun > 1) return 1;




                    if (i == 0)
                    {
                        if (kosegen(0, i, 1) > 1) return 1;
                        if (kosegen(0, 7 - i, -1) > 1) return 1;
                    }
                    else
                    {
                        if (kosegen(0, i, 1) > 1) return 1;
                        if (kosegen(i, 0, 1) > 1) return 1;

                        if (kosegen(0, 7 - i, -1) > 1) return 1;
                        if (kosegen(i, 7, -1) > 1) return 1;
                    }
                }

                return 0;
            }




                int[] d = new int[8];
                int[] satir = new int[8];
                int[] sutun = new int[8];
                int adt = 0;
                // 0,1,2,3,4,5,6,7,8,9
                // 0,0 

                for (d[0] = 0; d[0] < 64; d[0]++)
                {

                    sutun[0] = d[0] % 8;
                    satir[0] = d[0] / 8;
                    tahta[satir[0], sutun[0]]++;

                    for (d[1] = d[0] + 1; d[1] < 64; d[1]++)
                    {

                        sutun[1] = d[1] % 8;
                        satir[1] = d[1] / 8;
                        tahta[satir[1], sutun[1]]++;
                        if (kontrol() == 1) { tahta[satir[1], sutun[1]]--; continue; }

                        for (d[2] = d[1] + 1; d[2] < 64; d[2]++)
                        {
                            sutun[2] = d[2] % 8;
                            satir[2] = d[2] / 8;
                            tahta[satir[2], sutun[2]]++;
                            if (kontrol() == 1) { tahta[satir[2], sutun[2]]--; continue; }
                            for (d[3] = d[2] + 1; d[3] < 64; d[3]++)
                            {

                                sutun[3] = d[3] % 8;
                                satir[3] = d[3] / 8;
                                tahta[satir[3], sutun[3]]++;
                                if (kontrol() == 1) { tahta[satir[3], sutun[3]]--; continue; }
                                for (d[4] = d[3] + 1; d[4] < 64; d[4]++)
                                {

                                    sutun[4] = d[4] % 8;
                                    satir[4] = d[4] / 8;
                                    tahta[satir[4], sutun[4]]++;
                                    if (kontrol() == 1) { tahta[satir[4], sutun[4]]--; continue; }
                                    for (d[5] = d[4] + 1; d[5] < 64; d[5]++)
                                    {

                                        sutun[5] = d[5] % 8;
                                        satir[5] = d[5] / 8;
                                        tahta[satir[5], sutun[5]]++;
                                        if (kontrol() == 1) { tahta[satir[5], sutun[5]]--; continue; }
                                        for (d[6] = d[5] + 1; d[6] < 64; d[6]++)
                                        {

                                            sutun[6] = d[6] % 8;
                                            satir[6] = d[6] / 8;
                                            tahta[satir[6], sutun[6]]++;
                                            if (kontrol() == 1) { tahta[satir[6], sutun[6]]--; continue; }
                                            for (d[7] = d[6] + 1; d[7] < 64; d[7]++)
                                            {

                                                sutun[7] = d[7] % 8;
                                                satir[7] = d[7] / 8;
                                                tahta[satir[7], sutun[7]]++;
                                                if (kontrol() == 0)
                                                    adt++;
                                                tahta[satir[7], sutun[7]]--;
                                            }
                                            tahta[satir[6], sutun[6]]--;
                                        }
                                        tahta[satir[5], sutun[5]]--;
                                    }
                                    tahta[satir[4], sutun[4]]--;
                                }
                                tahta[satir[3], sutun[3]]--;
                            }
                            tahta[satir[2], sutun[2]]--;
                        }
                        tahta[satir[1], sutun[1]]--;
                    }
                    tahta[satir[0], sutun[0]]--;
                }
            }

        */
            #endregion



            //---------------------------- VİZE SONRASI NOTLAR  -----------------------------------

            #region merge: sıralı dosyaların sıralı bir şekilde birleştirilmesi

            /*
            int[,] dizi = new int[3, 4];

            int[] indis = new int[3];
            int[] merge = new int[12];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dizi[i, j] = i * 4 + j;
                }
            }

            for (int i = 0; i < 12; i++)
            {
                int ek = 0;
                while (indis[ek]==4)
                {
                    ek++;
                }

                for (int j = 0; j < 3; j++)
                {
                    if (indis[j]!=4)
                    {
                        if (dizi[ek, indis[ek]] > dizi[j, indis[j]])
                        {
                            ek = j;
                        }
                    }

                }
                Console.WriteLine(dizi[ek,indis[ek]]);

                indis[ek]++;
            }
            */
            #endregion


            #region huffman:  //wikpedia dan araştır sınavda çıkabilir
            /*

            btree[] bts = new btree[50];

            string data = "aaaaaabbbbaaacdefgjlkkmö";
            int[] frekans = new int[255];
            for (int i = 0; i < data.Length; i++)
            {
                frekans[data[i]]++;
            }

            for (int i = 0; i < data.Length; i++)
            {
                if (frekans[data[i]] > 0) {

                    bts[i] = new btree();
                    bts[i].data = frekans[data[i]];
                    bts[i].ch = data[i];

                }
            }



            */






            #endregion

            //ALGORİTMA HESAPLAMA KARMAŞIKLIĞI
            //int[] array = new int[10];
            #region O(n)
            /*

            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.WriteLine(max);
            */
            #endregion

            #region O(2n+1)=O(n)
            /*
            Console.WriteLine(n); //O(1)
            for (int i = 0; i < length; i++)
            {

            } O(n)
            for (int i = 0; i < length; i++)
            {

            } O(n)
            */
            #endregion

            #region O(n^2) n(n+1)/2=(n^2+2n)/2
            /*
            int inversion = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        inversion++;
                    }
                }
            }
            Console.WriteLine(inversion);
            */

            #endregion

            #region O(nlogn) //k tabanında
            /*
            for (int i = 0; i < n; i=i/k) //O(logn)
            {
                for (int i = 0; i < n; i++) //O(n)
                {
                    Console.WriteLine(n); //O(1)
                }
            }
            */

            #endregion

            #region O(n^3)
            /*
            long sum = 0;
            int n=6;
            for (int a = 1; a < n; a++)
            {
                for (int b = 1; b < n; b++)
                {
                    for (int c = 1; c < n; c++)
                    {
                        sum += a * b * c;
                    }
                }
            }
            Console.WriteLine(sum);
            */
            #endregion

            #region O(n*m) 1----->n    1----->m
            /*
            long sum = 0;
            int n = 5;
            int m = 5;
            for (int x = 1; x <= n; x++)
            {
                for (int y = 1; y <= m; y++)
                {
                    sum += x * y;
                }
            }
            Console.WriteLine(sum); 
            */
            #endregion

            //recursive metod kendini 1 kere çağırırsa O(n)
            //recursive metod kendini 2 kere çağırırsa O(2^n)



            //ARAMA ALGORİTMALARI

            //Linear Search: sıralı listede tüm elemanları okur O(n) 
            //Binary Search: ikiye bölerek ilerler O(logn)
            //Quick Sort: en iyi: O(n) en kötü O(n^2)



            #region Happy Number
            /*
            //19
            // 1^2+9^2=82
            // 8^2+2^2=68
            // 8^2+6^2=100  
            // 1^2+0^2+0^2=1 
            int happy = 94;
            int result = happy;

            while (true)
            {

                happy = result;
                result = isHappy(happy);
                if (result == 1)
                {
                    Console.WriteLine("Happy");
                    break;
                }
            }

            */

            #endregion



            #region armstrong sayı
            //153 //1*1*1+5*5*5+3*3*3=153
            /*
            int arm = 153;

            if (armstronSayi(arm)==true)
            {
                Console.WriteLine("Armstrong");

            }
            else
            {
                Console.WriteLine("Armstrong değil");
            }
            */
            #endregion

            #region Kaprekar sayıları   
            /*
             //55 , iki basamaklı bir sayıdır.
             // 55^2 = 3025 , sağdan iki basamak 25 , soldan iki basamak 30.
             //Bu iki sayının toplamı 30 + 25 = 55 yani sayının kendisidir.

             int kaprekar = 297;
             int square = kaprekar * kaprekar;

             int basamakSay = basamakSayisi(square);
             int payda = basamakSay - 1;
             int bolüm = 1;


             if (basamakSayisi(square)>5) 
             {
                 for (int i = 1; i < payda - 1; i++)
                 {
                     bolüm *= 10;
                 }
             }
             else
             {
                 for (int i = 1; i < payda; i++)
                 {
                     bolüm *= 10;
                 }
             }

             int left = square / bolüm;
             int right = square % bolüm;

             if (left+right==kaprekar)
             {
                 Console.WriteLine("Sayı kaprekar");
             }
             else
             {
                 Console.WriteLine("Sayı kaprekar değil");
             }
             Console.WriteLine("Basamak Sayısı{0}", basamakSayisi(square));
             Console.WriteLine("Basamak {0}",bolüm);

             Console.WriteLine(square);
             Console.WriteLine(left);
             Console.WriteLine(right);
            */
            #endregion


            #region Mükemmel Sayı

            // 6 --> 1+2+3=6 
            //Kendisi hariç pozitif tam bölenlerini toplamı kendisine eşit olan sayı
            /*
            int perfect = 8128;

            int sum = 0;
            for (int i = 1; i < perfect; i++)
            {
                if (perfect%i==0)
                {
                    sum += i;
                    Console.WriteLine(i);
                }

            }
            if (perfect==sum)
            {
                Console.WriteLine("Mükemmel Sayı");
            }


            */
            #endregion


            #region Palindromik sayılar

            ////12321
            //int pal = 123321;

            //int basamak = 0;

            ////
            //int payda = basamakSayisi(pal) - 1;
            //int bolüm = 1;
            //int left = 0;
            //int right = 0;
            //for (int i = 1; i < payda - 1; i++)
            //{
            //    bolüm *= 10;
            //}
            //if (basamakSayisi(pal) % 2 == 0)
            //{
            //    left = pal % bolüm;
            //    right = pal / bolüm;
            //    Console.WriteLine("Left: {0}", left);
            //    Console.WriteLine("Right: {0}", right);
            //}
            //else
            //{
            //    left = pal % bolüm;
            //    right = (pal / bolüm) / 10;
            //    Console.WriteLine("Left: {0}", left);
            //    Console.WriteLine("Right: {0}", right);
            //}
            //if (left == sayiTersCevir(right))
            //{
            //    Console.WriteLine("palindrom");
            //}

            //int ters = Convert.ToInt32(sayiTersCevir(left));

            ////

            //for (int i = 0; i < 9; i++)
            //{
            //    basamak = pal % 10;
            //    pal /= 10;
            //    //Console.WriteLine(basamak);

            //}


            //Console.WriteLine("ters {0}", ters);
            //// Console.WriteLine(basamakSayisi(pal));


            #endregion


            #region palindromik sayı v2 Düzgün Çalışan
            /*
            int pal = 1002001;
            int palV2 = pal;
            int bas = 0;
            int sum = 0;

            while (pal > 0)
            {
                bas = pal % 10;
                sum = (sum * 10) + bas;
                pal /= 10;
            }

            if (sum == palV2)
            {
                Console.WriteLine("Palindrom");
            }



            */
            #endregion


            #region Güçlü sayı

            /*
            //145 ---> 1! + 4! + 5! = 1+24+120=145
            //123 ---> 1! + 2! + 3! = 1+2+6=9
            int num = 145;


            if (num == Faktoriyel(num))
            {
                Console.WriteLine("Strong");
                Console.WriteLine(Faktoriyel(num));
            }
            else
            {
                Console.WriteLine("Not Strong");
                Console.WriteLine(Faktoriyel(num));
            }
            // Console.WriteLine(Faktoriyel(145));*/

            #endregion


            #region Arkadaş Sayılar
            /*
            //220’nin kendisi hariç pozitif bölenlerinin toplamı : 1 + 2 + 4 + 5 + 10 + 11 + 20 + 22 + 44 + 55 + 110 = 284

            //284’ün kendisi hariç pozitif bölenlerinin toplamı : 1 + 2 + 4 + 71 + 142 = 220


            Console.WriteLine("Sayı 1");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Sayı 2");
            int num2 = int.Parse(Console.ReadLine());


            int sum1 = 0;
            int sum2 = 0;

            for (int i = 1; i <num1; i++)
            {
                if (num1%i==0)
                {
                    sum1 += i;

                }

            }
            for (int i = 1; i < num2; i++)
            {
                if (num2 % i == 0)
                {
                    sum2 += i;
                }
            }

            if (sum1==num2 && sum2==num1)
            {
                Console.WriteLine("AMICABLE NUMBER");
            }

            else
            {
                Console.WriteLine("Not AMICABLE NUMBER");
            }
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
           */

            #endregion

            #region Bileşik Sayı Algortması
            /*
            //14 ---> 2*7
            // asall sayıların çarpımı olarak yazılabilen sayı
            //45 ---> 3*3*5


            int num = 45;
            bool isPrime = true;
            int bolen = 0;
            int i = 2;
            int temp = 0;
            int carpan = 1;
            for (i = 2; i < num; i++)
            {
                if (num % i == 0) //pozitif bölenleri
                {
                    temp = i;
                }


                if (temp % i == 0)
                {
                    Console.WriteLine("i"+i);
                }
               else
                {
                    Console.WriteLine("temp"+temp);
                }
            }



            // Console.WriteLine(Prime(7));
            //Console.WriteLine(isPrime);

        */
            #endregion

            #region Pozitif Asal Bölenleri
            //14 ---> 2*7
            // asall sayıların çarpımı olarak yazılabilen sayı
            //45 ---> 3*3*5


            //Console.WriteLine(PozitifOrtakBolen(45));
            //Console.WriteLine(PrimeNum(3));

            /*
            int num = 90;
            int bolen = 0;
            int prime = 0;

            for (int i = 1; i < num; i++)
            {

                if (num % i == 0)
                {
                    bolen = i;
                }
                else
                {
                    bolen = 1;
                }
                if (PrimeNum(bolen) )
                {
                    prime = bolen;
                    Console.WriteLine(prime);

                    continue;
                }
            }
            */


            //Console.WriteLine(prime);
            #endregion

            #region Anagram Sayı

            //123
            //321
            /*
            int a1 = 56981;
            int a2 = 18965;

            int b1 = 0;

            string c1 = "";

            int basamak = basamakSayisi(a1) + 1;

            for (int i = 1; i <= basamak; i++)
            {
                if (basamakSayisi(a1) == 1)
                {
                    basamak = basamakSayisi(a1) + 1;
                }

                b1 = a1 % 10;
                Console.WriteLine(b1);
                c1 += b1; //her bir basamağını c1 değişkenine atayarak tersten yazdırdık
                a1 /= 10;
            }

            if (c1==a2.ToString())
            {
                Console.WriteLine("Angram");
            }
            else
            {
                Console.WriteLine("Not Angram");
            }


            */
            #endregion



            #region Coin Sorusu Recursive
            // {8,3,2,1}  4 tl kaç farklı şekilde seçilir
            // 2+1+1  2+2  1+1+1+1  3+1  4 farklı şekilde seçilir

            /*
            int[] coin = { 8, 3, 2, 1 };

            Console.WriteLine(coinRec(coin,coin.Length,4));
            */
            #endregion

            #region Coin Sorusu İterative

            /*
            int[] arr = { 1, 2, 3 };
            int m = arr.Length;
            int n = 4;

            int[] table = new int[n + 1];

            for (int i = 0; i < table.Length; i++)
            {
                table[i] = 0;
            }

            table[0] = 1;

            for (int i = 0; i < m; i++)
            {
                for (int j = table[i]; j <=n; j++)
                {
                    table[j] += table[j - table[i]];
                }
            }
            Console.WriteLine(table[n]);
            */
            #endregion


            #region Gold Mine Problem

            //Input: mat[][] = {{1, 3, 3},
            //                 {2, 1, 4},  //ilk satır en büyük elemanı + ikinci satır en büyük elemanı + üçüncü satır en büyük elemanı
            //                  {0, 6, 4}}; // alt üst sağ sol hareket olacak
            // Output: 12
            /*
            int[,] gold = {{1, 3, 3,7},
                           {7, 1, 4,8},
                           {1, 6, 4,6},
                           {2 ,9 ,5 ,2}};

            // 1) dizinin [i,0] ına bak en büyüğü bul
            // 2) dizinin [i,1] ine bak en büyüğü bul
            // 3) dizinin [i,2] ye bak en büyüğü bul

            int b = gold[0, 0];
            int j = 0;
            int toplam = 0;
            for (int i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if (b < gold[j, i])
                    {
                        b = gold[j, i];

                    }
                }
                toplam += b;
                j = 0;
                b = 0;

            }

            Console.WriteLine(toplam);
            */
            #endregion

            #region Gold Mine Problem Recursive

            /*
            int[,] gold = {   { 1, 3, 1, 5 },
                              { 2, 2, 4, 1 },
                              { 5, 0, 2, 3 },
                              { 7, 6, 1, 2 } };
            int n = 4;
            int m = 4;
            int maxGold = 0;
            for (int i = 0; i < n; i++)
            {
                int sum = goldRecusrsive(gold, i, 0, n, m);
                maxGold = Math.Max(maxGold, sum);

            }
            Console.WriteLine(maxGold);
            */

            #endregion
            #region Denge İndexi

            // [3, 4, 1, 5, 2, 6]  5 denge indexi
            // 3 + 4 + 1 = 6 + 2

            /*
            int[] dizi = { 1,6,2,7}; //3+4+1 +5+ 2+6=21


            int left = 0;
            int right = 0;
            int count = 0;
            for (int i = 1; i < dizi.Length-1; i++)
            {
                left = SumArray(dizi, 0, i - 1);

                right = SumArray(dizi, i + 1, dizi.Length - 1);

                count++;
                if (left == right)
                {
                    Console.WriteLine(dizi[count]);
                }

            }


            */
            #endregion



            #region En büyük   //alan devam et
            /*
            int[,] grid = {{ 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                           { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                           { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                           { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0},
                           { 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0},
                           { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                           { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                           { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0} };

            int col = 13;
            int row = 8;

            area(row,col,grid);

            */


            #endregion



            //int a = 1;

            //a = (a << 2) & 7;
            //0001 a   
            //0100 a<<2
            //0111 7
            //Cevap =0100 4


            //a = (a >> 3) & 0xff00fff;
            //0001 a
            //0000 a>>3
            //1111 1111 0000 0000 1111 1111 1111  0xff00fff
            //0000 a>>3 & 0xff00fff    

            //a = (a << 3) & 0xff00fff;
            //0001 a
            //1000 a>>3
            //1111 1111 0000 0000 1111 1111 1111  0xff00fff
            //1000 a>>3 & 0xff00fff    


            //a = (a & 0xff00fff) | 4 ;
            //0001 a
            //1111 1111 0000 0000 1111 1111 1111 0xff00fff
            //0001 a & 0xff00fff
            //0100 3
            //0101 a & 0xff00fff | 3




            #region Sezar şifreleme (çok az kaldı) Kendi Çözümüm Dersle alakalı mı hatırlamıyorum. 
            /*
            // 123==353
            //  1+2=3 2+3=5 3+0=3
            int şifre = 536;
            int basamak = 0;
            int önceki = 0;
            int yeniŞifre = 0;
            int[] dizi = new int[basamakSayisi(şifre) + 2];
            dizi[0] = 0;
            dizi[basamakSayisi(şifre)+1] = 0;
          
            int i = 1;
            while (basamakSayisi(şifre) != 0)
            {
               
                basamak = şifre % 10;

                dizi[i] = basamak;

                önceki = dizi[i - 1];

                yeniŞifre += önceki;
                Console.WriteLine(yeniŞifre);
                şifre = şifre / 10;
                i++;
            }
            */
            #endregion


            #region Sırtçantası (Knapsack)


            /*
            int[] val = { 40, 100, 50, 60 };  //ne kadar değerli olduğu
            int[] wt = { 20, 10, 40, 30 };    //ağırlık
            int W = 60;                       // çantadaki toplam ağırlık  
            int n = val.Length;


            //knapsack(W, wt, val, n);

            //K={{40, 100, 50, 60 },
            //    {20, 10, 40, 30}}

            */
            #endregion



            //Console.WriteLine(test(0xff0000f));


            /* int a = 0xf00000f; //1111 0000 ... 0000 1111
             int b = 1;         //                   0001
             int c = 0x8000001; //1000 0000 ... 0000 0001
                                //                   0001
                                //                   0010    
             Console.WriteLine((a&b&c)<<1);
            */

            /*
            int a = 9; //1001
            string s = "";
            for (int i = 0; i < 5; i++)
            {
                if ((a|0)==1) 
                {             
                    s = s + "0";
                }
                else
                {
                    s = s + "1";
                }
                a >>= 1; 

            }

            //11101
            */



            /*
            int i = 1; //0001
            i = ((i << 2) + 4) >> 1;
                 //0100 (4) + 4=8 --> 1000
                 //                   0100
            Console.WriteLine(i);

            */
            //-------------------------------VİZE ÖNCESİ Mİ SONRASI MI HATIRLAMIYORUM----------------

            #region 5 elemanlı bir kümeninin alt kümeleri
            /*for (int i = 1; i < 32; i++)
            {
                int k = 1;
                int toplam = 0;
                for (int j = 0; j < 5; j++)
                {
                    if ((i & k) != 0) { Console.Write(j + " "); toplam += j; }
                    k <<= 1;
                
                }
                if (toplam==5)
                {
                    Console.WriteLine("Toplam"+toplam);
                }
                Console.WriteLine("satır sayısı"+i);
            }

            */
            #endregion

            #region 
            /*int n = 7;
            int[] x = new int[n + 1];
            int s = 2;
            int[] küme = { 12, 23, 45, 67, 89 };
            while (x[n] != 1)
            {
                for (int i = 0; i < n; i++)
                {
                    if (x[i]==1)
                    {
                        Console.Write(küme[i]+" ");
                    }
                }
                Console.WriteLine();
                x[0]++;
                for (int i = 0; i < n; i++)
                {
                    if (x[i]==s)
                    {
                        x[i] = 0;
                        x[i + 1]++;
                    }
                }
            }
            */
            #endregion

            #region  n vezir brute force-->tüm ihtimalleri denemek
            /*int[,] tahta = new int[8, 8];
            int[] vezir = new int[8];
            int length = 8;
            int adet = 0;
            int[] x = new int[9];
            while (x[8]==0)
            {
                for (int i = 0; i < length; i++)
                {
                    tahta[i, vezir[i]] = 1;
                }
                for (int i = 0; i < length; i++)
                {
                    tahta[i, vezir[i]] = 0;
                }
                if (kontrol(tahta))
                {
                    adet++;
                    if (adet == 1) yaz(tahta);
                }
                x[0]++;
                for (int i = 0; i < length; i++)
                {
                    if(x[i]==8)
                    {
                        x[i] = 0;
                        x[i + 1]++;

                    }
                }
               


            }*/
            /* for ( vezir[0] = 0; vezir[0] < length; vezir[0]++)
             {
                 tahta[0, vezir[0]]=1;
                 for (vezir[1] = 0; vezir[1]< length; vezir[1]++)
                 {
                     if (vezir[1] == vezir[0]) continue;
                     tahta[1, vezir[1]] = 1;
                     for (vezir[2] = 0; vezir[2] < length; vezir[2]++)
                     {
                         if (vezir[2] == vezir[0]) continue;
                         if (vezir[2] == vezir[1]) continue;

                         tahta[2, vezir[2]] = 1;
                         for (vezir[3] = 0; vezir[3] < length; vezir[3]++)
                         {
                             if (vezir[3] == vezir[0]) continue;
                             if (vezir[3] == vezir[1]) continue;
                             if (vezir[3] == vezir[2]) continue;
                             tahta[3, vezir[3]] = 1;
                             for (vezir[4] = 0; vezir[4] < length; vezir[4]++)
                             {
                                 if (vezir[4] == vezir[0]) continue;
                                 if (vezir[4] == vezir[1]) continue;
                                 if (vezir[4] == vezir[2]) continue;
                                 if (vezir[4] == vezir[3]) continue;
                                 tahta[4, vezir[4]] = 1;
                                 for (vezir[5] = 0; vezir[5] < length; vezir[5]++)
                                 {
                                     if (vezir[5] == vezir[0]) continue;
                                     if (vezir[5] == vezir[1]) continue;
                                     if (vezir[5] == vezir[2]) continue;
                                     if (vezir[5] == vezir[3]) continue;
                                     if (vezir[5] == vezir[4]) continue;

                                     tahta[5, vezir[5]] = 1;
                                     for (vezir[6] = 0; vezir[6] < length; vezir[6]++)
                                     {
                                         if (vezir[6] == vezir[0]) continue;
                                         if (vezir[6] == vezir[1]) continue;
                                         if (vezir[6] == vezir[2]) continue;
                                         if (vezir[6] == vezir[3]) continue;
                                         if (vezir[6] == vezir[4]) continue;
                                         if (vezir[6] == vezir[5]) continue;
                                         tahta[6, vezir[6]] = 1;
                                         for (vezir[7] = 0; vezir[7] < length; vezir[7]++)
                                         {
                                             if (vezir[7] == vezir[0]) continue;
                                             if (vezir[7] == vezir[1]) continue;
                                             if (vezir[7] == vezir[2]) continue;
                                             if (vezir[7] == vezir[3]) continue;
                                             if (vezir[7] == vezir[4]) continue;
                                             if (vezir[7] == vezir[5]) continue;
                                             if (vezir[7] == vezir[6]) continue;
                                             tahta[7, vezir[7]] = 1;
                                             if (kontrol(tahta)) { adet++;
                                                 if (adet == 1) yaz(tahta);
                                             }
                                             tahta[7, vezir[7]] = 0;
                                         }
                                         tahta[6, vezir[6]] = 0;
                                     }
                                     tahta[5, vezir[5]] = 0;
                                 }
                                 tahta[4, vezir[4]] = 0;
                             }
                             tahta[3, vezir[3]] = 0;
                         }
                         tahta[2, vezir[2]] = 0;
                     }
                     tahta[1, vezir[1]] = 0;
                 }
                 tahta[0, vezir[0]] = 0;
             }
             Console.Write(adet);*/
            #endregion

            #region Substring

            //longest common substring 
            //2 farklı string içerisinde en uzun ortak altstring bulma
            //AVCDEFGHJKL
            //12AB35DEFG456ABC
            //AB
            //DEFG
            //ABC
            //Dinamik programlama problemi-Diziler kullanılarak çözülür

            //
            //RECURSİVE YAZ SINAVDA ÇIKABİLİR
            /*string q = "abcdefgh";
            string w = "12abbabcd";

            int[,] lcs = new int[q.Length+1,w.Length+1]; //q.length kadar satır //w kadar sütun

            int eb = 0;

            for (int i = 0; i <q.Length; i++)
            {
                for (int j = 0; j < w.Length; j++)
                {
                    if (q[i] == w[j])
                    {
                        if(i*j==0)
                        {
                            lcs[i,j] = 1;
                        }
                        else
                        {
                            lcs[i, j] = lcs[i-1,j-1]+1;
                            if (eb<lcs[i,j])
                            {
                                eb = lcs[i, j];
                            }
                        }
                    }
                }
            }
            Console.WriteLine(eb);*/
            #endregion

            #region longest common subsequence
            //string w = "a1ab2djk3";
            //yan yana olmadan sırala
            // a1 subsequence
            //ab hem substring hem subsequence
            //12 subsequence
            //123 subsequence
            //abd3 subsequence
            //dinamik programlama-diziler ile çözülür
            /*string q = "abcdefgh123";
            string w = "a1ab2djk3";
            int eb = 0;
            int[,] lcs = new int[q.Length, w.Length];
            for (int i = 0; i < q.Length; i++)
            {
                for (int j = 0; j < w.Length; j++)
                {
                    if (q[i] == w[j])
                    {
                        if (i * j == 0) lcs[i, j] = 1;
                        else
                        {
                            lcs[i, j] = lcs[i - 1, j - 1] + 1;
                            if (eb < lcs[i, j]) eb = lcs[i, j];
                        }
                    }
                    else
                    {
                        if (i*j==0)
                        {
                            lcs[i, j] = 0;
                        }
                        else
                        {
                            if (i * j == 0) lcs[i, j] = 0;
                            else max(lcs[i - 1, j], lcs[i, j - 1]);
                        }
                    }
                }
            
            }
            Console.WriteLine(eb);*/






            #endregion

            #region Hashing
            //hasıng nedir
            //arama -->insert,delete arama
            //veritabanı mükemmmel
            //ram de arama yapar
            //sıralı verileri sorted data log(n)
            //sırasız verileri O(n)
            //ram deki arama hızlandırmamız hashing dediğimiz hash funcktion 
            //diziler kullanılır O(1)

            //veri setinin limitli yada ram de sıkıntı olmamalı hash çok rahat
            //sınırlı kaynak,ram sınırlı veri seti sınırlı
            //veriler string olacak
            //hash fonkl. belirleyip bu fonsiyona göndermek ve buradfan değer elde etmek
            //hash funcktion sayı dizisinin indisi olacak
            //hash[hf(text)]=text;
            //Hash fonk-->evently-distributed homojen dağılmalı
            // hash fonk belirlenirken bölme kullanılır
            //çarpamada kullanılarbilir
            //Bölmenin maliyeti daha fazla
            //3. özellik çok komplek olmamalı anlaşılır olmalı sistemi yormamalı
            //taşma olmamalı

            /*Console.WriteLine(hf("bülent"));
            Console.WriteLine(hf("mehmet"));
            Console.WriteLine(hf("fuat"));

            hash[hf("bülent")] = "bülent";
            hash[hf("mehmet")] = "mehmet";
            hash[hf("fuat")]   = "fuat";

            hInsert("mustafa");
            Console.WriteLine(hashSearch("mustafa"));
            Console.WriteLine(hashSearch("bülent"));*/
            #endregion

            #region Hasing2
            /*
            hInsert("ayla");
            Console.WriteLine(hashSearch("ayla"));
            hInsert("alay");
            Console.WriteLine(hashSearch("alay"));
            Console.WriteLine(hashSearch("ayla"));*/
            #endregion

            #region Sıkıştırma

            //kayıplı sıkıştırma 
            //ilk veri sıkıştırıldıktan sonra ilk veriden farklı olur
            //bir mikttar kayıp-->resim görüntüleme

            //kayıpsız sıkıştırma
            //ilk veri ile aynı

            //2 temel algoritma

            //Entropi-->SAYISAL  BİÇİMİNDE İFADE EDİLEBİLR
            //2 TEMEL METODU VAR
            //Hufman
            //Arithmetic codding verimi daha yüksek

            //Dictionary based 

            //AABACD 6 karakterlik string
            //6 BYTE=48 BIT olarak saklarız
            //A 00
            //B 01
            //C 10
            //D 11
            //her biri için 2 bit alan ayırsak toplamda 12 bit olacak şekile getirlmiş oluruz
            //48 biti 12 bite dönüştürmüş olduk

            #endregion

            #region Hufman
            //Yüksek freakansları az bit ile temsil eder
            //binary ikilii ağaç
            /*
            Btree[] bts = new Btree[10];
            for (int i = 0; i < 10; i++)
            {
                bts[i] = new Btree();
                bts[i].data = i + 1;
                bts[i].ch = (byte)'A' + i;
                //A,B,C,D,E,F,G,H,I,J
            }
            tree(bts);
            yazBtree(bts[0], "");
            yazBtreeSonuc(bts[0]);*/
            #endregion

            #region Sıkıştırma2
            /* string data = "AABBABBBBAAAACDEF";

             Btree[] bts = new Btree[255];
             int[] frekans = new int[255];
             for (int i = 0; i < data.Length; i++)
             {
                 frekans[data[i]]++;

             }

             for (int i = 0; i < data.Length; i++)
             {
                 if (frekans[data[i]] > 0)
                 {
                     bts[i] = new Btree();
                     bts[i].data = frekans[data[i]];
                     bts[i].ch = data[i];
                     frekans[data[i]] = 0;
                 }
             }
             Array.Sort(bts, (object x, object y) =>
             {
                 int a = 0;


                 if (x == null && y == null) return 0;
                 if (x == null) return 1;
                 if (y == null) return -1;
                 if (((Btree)x).data < ((Btree)y).data) a = -1;
                 if (((Btree)x).data > ((Btree)y).data) a = 1;
                 return a;
             });
             tree(bts);
             yazBtree(bts[0], "");
             string hufman = "";

             for (int i = 0; i < data.Length; i++)
             {
                 hufman += huf[data[i]];
             }
             Console.WriteLine(hufman);
             Console.WriteLine(hufman.Length);*/


            /*
            //ters çevirme--> 0101....--->ABAB.....
            string ln = "";
            string unzip = "";
            for (int i = 0; i < hufman.Length; i++)
            {
                ln += hufman[i];
                bool find = true;
                int adet = 0;
                int jvalue = 0;
                for (int j = 0; j < 255; j++)
                {
                    if (karakter[j] > 0)  if (reverse(huf[j], ln)) { adet++; jvalue = j; } 

                }
           if(adet == 1) { ln = ""; unzip += ((char)jvalue).ToString(); }

                adet = 0;
            }
            //yazBtreeSonuc(bts[0]);
            Console.WriteLine(unzip);
            Console.WriteLine(data);*/


            #endregion

            #region ekleme ve arama
            /*for (int i = 0; i < hash.Length; i++)
            {
                hash[i] = "";
            }

            hashInsertNode("ayla");
            hashInsertNode("alay");
            Console.WriteLine(hashSearchNode("ayla"));
            Console.WriteLine(hashSearchNode("alay"));*/
            #endregion

            #region pascal üçgeni
            //    1
            //  1   1
            // 1  2  1
            //1  3  3  1
            /*
                        string s = "1";
                        for (int i = 0; i < 4; i++)
                        {
                            string st = "1";
                            for (int j = 1; j < s.Length; j++)
                            {
                                int sayı = int.Parse(s[j].ToString()) + int.Parse(s[j - 1].ToString());
                                st = st + sayı.ToString();
                            }
                            st += "1";
                            s = st;
                            Console.WriteLine(st);
                        }*/

            #endregion

            #region np hard knapsack problem
            // Sırt çantası problemi 0-1 knapsack
            //Capacity ağırlık problemi
            /*int[] deger = { 10, 20, 30, 40, 25 };
            int[] agırlık = { 3, 4, 5, 6, 7 };
            int kapasite = 6;
            Console.WriteLine(knapSack(deger, agırlık, agırlık.Length-1, kapasite)); */
            //Çantayı doldurma zorunluluğu yok
            #endregion

            //----------------------------- BİTWİSE İŞLEMLERİ ------------------------------

            #region BİTWİSE
            //----------------------------------------------------------------------------------//

            //En soldaki bit (Least Signed Bit) =1 NEGATİF
            //En sağdaki bit (Most Signed Bit) =0 POZİTİF

            //signed 8 bit ise 1 bit işaret biti olur bu yüzden 2^7 kadar veri yazılır
            //unsigned 8 bit ise 2^8 kadar veri yazılır

            /*
            uint a = 0x12ab;
                    //0001001......---> 0İle başladığı için POZİTİF
            int b = (int)a;
            Console.WriteLine(a);
            Console.WriteLine(b);

            a = 0x80000000;
                //100000000000000000000000 ---> 1 ile başladığı için NEGATİF
            b = (int)a;
            Console.WriteLine(a);
            Console.WriteLine(b);
            */

            //----------------------------------------------------------------------------------//

            /*
            uint data = 21;
                      //10101
            Console.WriteLine(data);
            uint mask = 0xfffffffe;
                      //...01 1110
            Console.WriteLine(data & mask);
                        //10101
                        //11110
          //data & mask   10100 == 20
            */

            //----------------------------------------------------------------------------------//

            /*
            uint a = 1; //0001
            //SOLA SHİFT
            //a = a << 1; //0010 =2
            //a = a << 2; //0100 =4
              a = a << 3; //1000 =8
            Console.WriteLine(a);

            //SAĞA SHİFT
            int b = 123;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10000000; i++)
            {
                b = i >> 1;
                b = i >> 1;
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            */

            //----------------------------------------------------------------------------------//

            /*
            uint a = 0xffff0000; //1111 1111 1111 1111 0000 0000 0000 0000
            //BİNARY KARŞILIĞINI YAZ 
            //uint b = 1;         //TERSTEN YAZDIRIR
            uint b = 0x80000000;  //DÜZDEN YAZDIRIR
            string s = "";
            for (int i = 0; i <32; i++)
            {
                if ((a&b)==0)
                {
                    Console.WriteLine("0");
                    //s += "0";

                }
                else
                {
                    Console.WriteLine("1");
                    //s += "1";

                }
                b = b << 1;
            }
            Console.WriteLine(s);

            */

            //----------------------------------------------------------------------------------//

            /*
            //a sayısının 3 7 ve 11. bitlerini diğer bitlere zarar vermeden 1 yap

            uint a = 12; //1100
            uint mask = 0x00000444;
                    //0000 ... 0100 0100 0100
                    //          7.    4.  3.bit 

            Console.WriteLine(a | mask);
            Console.WriteLine(mask);
            */

            //----------------------------------------------------------------------------------//

            /*
            //a sayısının içerisindeki değeri 1 olan bitleri bul
            uint a = 12; 1100
            uint mask = 0x00000444; 0000 0000 0000 0000 0000 0100 0100 0100

            int adet = 0;
            for (int i = 0; i < 32; i++)
            {
                if ((a&mask)!=0)
                {
                    adet++;
                    mask <<= 1;
                }
            }
            Console.WriteLine(adet);
            */

            //----------------------------------------------------------------------------------//

            /*
            //İlk 16 bitin ve son 16 bitin hangisinde daha çok 1 vardır
            
            uint a = 0xffff0000; // 1111 1111 1111 1111 0000 0000 0000 0000
            int msfCount = 0;
            int lsfCount = 0;

            int b = 1; //0001
            uint c = 0x80000000; //1000 0000000000000000
            
            for (int i = 0; i < 16; i++)
            {
                if ((a&b)!=0) //0001
                {
                    msfCount++;
                }
                if ((a&c)!=0) //1000
                {
                    lsfCount++;

                }
                c >>= 1; //0100
                b <<= 1; //0010
            }
            if (msfCount>lsfCount)
            {
                Console.WriteLine("MSB:{0}",b);
            }
            else
            {
                Console.WriteLine("LSB:{0}",c);
            }
           */

            //----------------------------------------------------------------------------------//

            /*
            //32 bitlik sayıyı rotate edelim
            uint a = 1;
            uint b = 0x80000000;
          

            for (int i = 0; i < 40; i++)
            {
                if ((a & b) != 0)
                {
                    a = a << 1;
                    a++;
                }
                else
                {
                    a <<= 1;
                }
                Console.WriteLine(a);
            }

            */

            //----------------------------------------------------------------------------------//

            /*
            //0 ları 1 1 leri 0 yapalım
            uint a = 0;
            uint b = 1;
            uint c = 0xfffffffe;
            uint d = 1;
            for (int i = 0; i < 32; i++)
            {
                if ((a&b)!=0)
                {
                    a = a & c;
                }
                else
                {
                    a = a | d;
                    b <<= 1;
                    c <<= 1;
                    c++;
                    d <<= 1;
                }
                Console.WriteLine(a);
            }

            */

            //----------------------------------------------------------------------------------//

            /*
            //en yüksek seviyeli 5biti 1arttıralım.

            //xxxxxyyyyyyyyy

            uint a = 1231654;
            //00110
            uint bes = a & 0xf8000000;
            bes = bes + 0x080000000;
            a = a & 0x07fffffff;
            a = a | bes;
            //32,31,30,29,28
            //0 0 0 0 1 000000
            //x  x  x  x  x 000000

            //5.soru
            uint a = 123456;
            uint b = a & 0x1f;
            b = b << 28;
            a = a + b;
            */

            //----------------------------------------------------------------------------------//

            #endregion









            Console.ReadLine();



        }
    }
}
