
namespace CSharp
{ 
    using System;
    
    public sealed class HTMLTokenVisitor: /*NullTokenVisitor*/ ITokenVisitor //После добавления перестает реализовываться метод Visit. В классе NullTokenVisitor параметры метода Visit были пустыми 
    {
        public void Visit(IDirectiveToken token)
        {
            SpannedFilteredWrite("directive", token);
        }
        public /*override*/ void Visit(ILineStartToken line) //Добавили для реализации унаследованного метода Visit 
        {
            Console.Write("<span class=\"line_number\">");
            Console.Write("{0,3}", line.Number()); //Not WriteLine!!!
            Console.Write("</span>");
        }
        public /*override*/ void Visit(ILineEndToken t)
        {
            Console.WriteLine(); //Not Write!!!
        }
        public /*override*/ void Visit(IIdentifierToken token)
        {
            //Console.Write(token.ToString());
            SpannedFilteredWrite("identifier", token);
        }
        public /*override*/ void Visit(ICommentToken token)
        {
            //Console.Write("<span class=\"comment\">");
            //FilteredWrite(token);
            //Console.Write("</span>");
            SpannedFilteredWrite("comment", token);
        }
        public /*override*/ void Visit(IKeywordToken token)
        {
            //Console.Write("<span class=\"keyword\">");
            //FilteredWrite(token);
            //Console.Write("</span>");
            SpannedFilteredWrite("keyword", token);
        }
        public /*override*/ void Visit(IWhiteSpaceToken token)
        {
            Console.Write(token.ToString());
        }
        public /*override*/ void Visit(IOtherToken token)
        {
            FilteredWrite(token);
        }
        private void FilteredWrite(IToken token)
        {
            string src = token.ToString();
            for (int i = 0; i != src.Length; i++)
            {
                string dst;
                switch (src[i])
                {
                    case '<':
                        dst = "&lt;"; break;
                    case '>':
                        dst = "&gt;"; break;
                    case '&':
                        dst = "&amp;"; break;
                    default:
                        dst = new string(src[i], 1); break;
                }
                Console.Write(dst);
            }
        }
        private void SpannedFilteredWrite(string spanName, IToken token)
        {
            Console.Write("<span class=\"{0}\">", spanName);
            FilteredWrite(token);
            Console.Write("</span>");
        }
    }
}
