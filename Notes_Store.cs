using System;
using System.Collections.Generic;
using System.IO;

namespace Solution
{

    public class NotesStore
    {
        class Note{
            public string name{get; set;}
            public string state{get; set;}
        }    
        private enum state{
            completed,
            active,
            others
        }
        private List<Note> notes;
        
        public NotesStore() {
            notes = new List<Note>();
        }
        public void AddNote(String state, String name) {
            if (string.IsNullOrEmpty(name)){
                throw new Exception("Name cannot be empty");
            }
            
            if(!Enum.IsDefined(typeof(state), state)){
                throw new Exception($"Invalid state {state}");
            }
            
            notes.Add(new Note { name = name, state = state });
        }
        public List<String> GetNotes(String state) {
            if(!typeof(state).IsEnumDefined(state)){
                throw new Exception($"Invalid state {state}");
            }
            
            return (from note in notes where note.state == state select note.name).ToList();
        }
    } 

    public class Solution
    {
        public static void Main() 
        {
            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++) {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    } else {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}
