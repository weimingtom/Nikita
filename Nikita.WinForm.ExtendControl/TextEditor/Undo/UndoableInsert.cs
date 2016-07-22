﻿// Decompiled with JetBrains decompiler
// Type: Nikita.WinForm.ExtendControl.Undo.UndoableInsert
// Assembly: Nikita.WinForm.ExtendControl, Version=2.0.0.922, Culture=neutral, PublicKeyToken=4d61825e8dd49f1a
// MVID: BBD0169A-B000-4932-857E-AD5E2FD7AB69
// Assembly location: D:\GitHub\学习使用\Nikita-2013\Nikita.Assist.CodeMaker\dll\Nikita.WinForm.ExtendControl V3.0\支持T-SQL版本\Nikita.WinForm.ExtendControl.dll

using Nikita.WinForm.ExtendControl.Document;
using System;

namespace Nikita.WinForm.ExtendControl.Undo
{
  public class UndoableInsert : IUndoableOperation
  {
    private IDocument document;
    private int offset;
    private string text;

    public UndoableInsert(IDocument document, int offset, string text)
    {
      if (document == null)
        throw new ArgumentNullException("document");
      if (offset < 0 || offset > document.TextLength)
        throw new ArgumentOutOfRangeException("offset");
      this.document = document;
      this.offset = offset;
      this.text = text;
    }

    public void Undo()
    {
      this.document.UndoStack.AcceptChanges = false;
      this.document.Remove(this.offset, this.text.Length);
      this.document.UndoStack.AcceptChanges = true;
    }

    public void Redo()
    {
      this.document.UndoStack.AcceptChanges = false;
      this.document.Insert(this.offset, this.text);
      this.document.UndoStack.AcceptChanges = true;
    }
  }
}