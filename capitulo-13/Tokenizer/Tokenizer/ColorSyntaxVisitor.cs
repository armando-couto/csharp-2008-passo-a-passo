using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Tokenizer
{
    sealed class ColorSyntaxVisitor : ITokenVisitor
    {
        public ColorSyntaxVisitor(RichTextBox rtb)
        {
            this.target = rtb;
            this.target.Document.Blocks.Clear();
        }

		// to do: implement all the Visit methods        

		private readonly RichTextBox target;       
    }
}
