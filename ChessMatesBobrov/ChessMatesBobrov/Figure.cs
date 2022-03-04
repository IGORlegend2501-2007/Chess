using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessMatesBobrov
{
    public abstract class Figure
    {
        public int Index0 { get; protected set; }
        public int Index1 { get; protected set; }
        public Image Sprite { get; protected set; }
        public bool IsWhite { get; protected set; }

        public Figure()
        {
            this.Index0 = -1;
            this.Index1 = -1;
            this.Sprite = new Bitmap(1, 1);
            IsWhite = false;
        }
        public bool TryMove(int newIndex0, int newIndex1, ref bool whiteTurn, List<Figure> white, List<Figure> black) {
            if(CheckMove(newIndex0, newIndex1, ref whiteTurn, white, black))
            {
                this.Index0 = newIndex0;
                this.Index1 = newIndex1;
                whiteTurn = !whiteTurn;
                return true;
            }
            return false;
        }
        public bool CheckListFigurePosition(List<Figure> figures, int newIndex0, int newIndex1)
        {
            return false;
        }
        public virtual bool CheckMove(int newIndex0, int newIndex1, ref bool whiteTuen, List<Figure> white, List<Figure> black) { return false; }
    }
    public class Pawn : Figure
    {
        public Pawn(int Index0, int Index1, bool isWhite)
        {
            this.Index0 = Index0;
            this.Index1 = Index1;
            this.IsWhite = isWhite;
            this.Sprite = isWhite ? new Bitmap("image/white/pawn.png") : new Bitmap("image/black/pawn.png");
        }

        public override bool CheckMove(int newIndex0, int newIndex1, ref bool whiteTurn, List<Figure> White, List<Figure> Black)
        {
            if (newIndex1 == this.Index1 && whiteTurn && IsWhite && (newIndex0 == this.Index0 - 1 || newIndex0 == 4) && CheckListFigurePosition())
            {             
                return true;
            }
            else if (newIndex1 == this.Index1 && !whiteTurn && !IsWhite && (newIndex0 == this.Index0 + 1 || newIndex0 == 3))
            {
                return true;
            }
            return false;
        }
    }
}