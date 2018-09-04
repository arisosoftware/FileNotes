

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace FileNotes.ViewModel
{


   /// <summary>
   /// 
   /// </summary>
    public class FolderItem  :  INotifyPropertyChanged
    { 
 
        public event PropertyChangedEventHandler PropertyChanged;
 
        public virtual void SendPropertyChanged(String propertyName)
        {
          if ((this.PropertyChanged != null))
          {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }        
        }


        public const string Title_Name = "Title";
        protected string _title;
        public string Title
        {
            get {  return this._title; }
            set
            {
                if (_title == value)
                       return;
                this._title = value;
                 this.SendPropertyChanged(Title_Name);
            }
        }
       
     
        public const string SubItems_Name = "SubItems";
        protected ObservableCollection<FolderItem> _subitems;
        public ObservableCollection<FolderItem> SubItems
        {
            get {  return this._subitems; }
            set
            {
                if (_subitems == value)
                       return;
                this._subitems = value;
                 this.SendPropertyChanged(SubItems_Name);
            }
        }
       
     } 

   /// <summary>
   /// 
   /// </summary>
    public class FileItem  :  INotifyPropertyChanged
    { 
 
        public event PropertyChangedEventHandler PropertyChanged;
 
        public virtual void SendPropertyChanged(String propertyName)
        {
          if ((this.PropertyChanged != null))
          {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }        
        }


        public const string FileName_Name = "FileName";
        protected string _filename;
        public string FileName
        {
            get {  return this._filename; }
            set
            {
                if (_filename == value)
                       return;
                this._filename = value;
                 this.SendPropertyChanged(FileName_Name);
            }
        }
       
     
        public const string FileSize_Name = "FileSize";
        protected int _filesize;
        public int FileSize
        {
            get {  return this._filesize; }
            set
            {
                if (_filesize == value)
                       return;
                this._filesize = value;
                 this.SendPropertyChanged(FileSize_Name);
            }
        }
       
     
        public const string FileTime_Name = "FileTime";
        protected DateTime _filetime;
        public DateTime FileTime
        {
            get {  return this._filetime; }
            set
            {
                if (_filetime == value)
                       return;
                this._filetime = value;
                 this.SendPropertyChanged(FileTime_Name);
            }
        }
       
     } 

   /// <summary>
   /// 
   /// </summary>
    public class MainViewModel  :  INotifyPropertyChanged
    { 
 
        public event PropertyChangedEventHandler PropertyChanged;
 
        public virtual void SendPropertyChanged(String propertyName)
        {
          if ((this.PropertyChanged != null))
          {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
          }        
        }


        public const string FolderItem_Name = "FolderItem";
        protected FolderItem _folderitem;
        public FolderItem FolderItem
        {
            get {  return this._folderitem; }
            set
            {
                if (_folderitem == value)
                       return;
                this._folderitem = value;
                 this.SendPropertyChanged(FolderItem_Name);
            }
        }
       
     
        public const string FileItem_Name = "FileItem";
        protected ObservableCollection<FileItem> _fileitem;
        public ObservableCollection<FileItem> FileItem
        {
            get {  return this._fileitem; }
            set
            {
                if (_fileitem == value)
                       return;
                this._fileitem = value;
                 this.SendPropertyChanged(FileItem_Name);
            }
        }
       
     } 


}



