using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaesarCipher.Models
{
    public class Cipher
    {
        //PROPERTIES
        [Required]
        public string Text { get; set; }

        [Required]
        public int Shift { get; set; }

        [Required]
        public bool IsDecrypt { get; set; }

        public string Results { get; set; }

        //METHODS

        // The following methods are responsible for the encryption or decryption of the text the user entered based on the values they entered.
        public void Encrypt()
        {
            // If the model determines that the text needs to be decrypted, it changes the key to it's additive inverse.
            if (this.IsDecrypt == true)
            {
                this.Shift = -this.Shift; 
            }
            char[] buffer = this.Text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                // Declares and initalizes character variable to store char in the buffer.
                char character = buffer[i];
                // Determines if the char is a letter, which would mean it should be shifted.
                if (char.IsLetter(character))
                {
                    // Checks to see if the char is lower case, and converts to upper if it is.
                    bool lowerCase = char.IsLower(character);
                    if (lowerCase) character = char.ToUpper(character);
                    // Shifts the char.
                    character += (char)this.Shift;
                    // Validation to make sure we are only both only getting characters from the alphabet.
                    if (character > 'Z')
                    {
                        character -= (char)26;
                    }
                    else if (character < 'A')
                    {
                        character += (char)26;
                    }
                    // Stores the shifted char in the buffer, after reconverting to lower case if necessary.
                    if (lowerCase) character = char.ToLower(character);
                    buffer[i] = character;
                }
                else
                // Skips the shifting of the char if it is not a letter.
                buffer[i] = character;
            }
            // Stores the encrypted string as the string 'this.Results'.
            this.Results = new string(buffer);
        }
    }
}