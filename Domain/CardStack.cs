﻿using System.ComponentModel.DataAnnotations;

namespace Flashcards.TwilightSaw.Domain;

public class CardStack
{
    [Key]
    public int StackId { get; set; }
    public string Name { get; set; }

    public List<Flashcard> Flashcards { get; set; }
}