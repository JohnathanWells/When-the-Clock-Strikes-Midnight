VAR tomb_joe = 1
VAR ale_night_tosh = 0
VAR phillip_well = 0
VAR ale_angry = 0
VAR joe_remains = 0
VAR joe_rumors = 0
VAR doctor_rumors = 0
VAR church_sighting = 0
VAR phillip_remains_found = 0
VAR brut_daughter_discoverer = 0
VAR church_letter = 0

->Intro

==Intro==
Mr. Ale: Good evening Reverend, let me know how I can help you find that beast.
->Hub

==Hub==
+[(Leave) Thank you. God bless you.]->Leave
+{tomb_joe} [Who vandalized Joe's tomb?]->Joe_Tomb
+{ale_night_tosh} [Were you stealing from Phillip?]->Well
*{church_letter == 2}[Do you recognize this letter?]->Letter
+[Have you seen anything interesting?]->Information
+[How is your family?]->Family

==Joe_Tomb==
Mr. Ale: Oh, the whole 'murderer' thing? No one knows who did it...
{ale_angry == 1: 
(Mr. Ale doesn't seem interested in continuing the conversation.)
}
    +   {ale_angry == 0}[But...?]
        Mr. Ale: But nothing, I don't like talking behind people's back or spreading rumors.
        Mr. Ale: ...That said... Joe wasn't very liked. He was the only barber in town, and a bloody good one at that, but he was also... difficult to be around.
        Mr. Ale: He also didn't grow up here. That didn't help.
    +   +   [Where was he from?]
            Mr. Ale: Supposedly he came from a city. Wanting a quiet life and all that. 
    +   +   +   ['Supposedly']
                Mr. Ale: Well... rumor has it he didn't chose to leave, and that's all I'll elaborate. If you want to know more, you should talk to Greg or Brut. 
                
                Mr. Ale: I'm actually surprised someone put a headstone to begin with, we only found some of his thorn bloodied clothes in the woods.
                ~joe_remains = 1
                {joe_rumors == 0: 
                ~joe_rumors = 1
                }
                Mr. Ale: Anything else I can help you with?
    -   -   -   ->Hub
    +   ->
        ->Hub

==Well==
Mr. Ale: No! Of course not!
    +   [Very well.] ->Hub
    +   [Tosh says he saw you.]
        Mr. Ale: Oh, that...
        Mr. Ale: Look, I wasn't really stealing from Phillip. That well wasn't built by him, it belonged to his father, and he never had any issue with letting me use it!
        Mr. Ale: I run a tavern and can't spare an hour walk to the river every time I need to make a drink. 
        Mr. Ale: Oh, but Phillip would not let anyone use his precious well! That bloody fool...
            ~phillip_well = 1
    +   +   [Sounds like you are happy he's dead.]
            Mr. Ale: Of course I'm not! But I do wonder if this all started because he started throwing a fit at the wrong person.
    -   -   ->Hub
    +   +   [Did you kill him?]
            Mr. Ale: H-heavens, no! Are you insane?!
            ~ale_angry = 1
            (The accusation seems to have angered him.)
    -   -   ->Hub
    +   +   {phillip_remains_found}[I found a skeleton in the well.]
            Mr. Ale: Are you serious? Oh my god...
            Mr. Ale: We buried Phillip though, could it have been someone else's? 
            Mr. Ale: I wonder how long it's been there? I have admittely never examined it too closely, but the water never tasted any different from the other well... 
            Mr. Ale: This is bloody inconvenient. Did you find out something else?
    +   +   +   [No. But I have more questions.]
                Mr. Ale: Sure, go ahead.
    -   -   -   ->Hub
    
==Letter==
Mr. Ale: Should I?
+   [Not a lot of literate married men here]
    Mr. Ale: Sorry Father, can't say I recognize this letter. My writing is quite different as well, you can see it on the sign outside.
    (This appears to be true.)
    ->Hub

==Family==
Mr. Ale: The wife and son are doing fine. There's obviously no business today, so they're just cleaning the inn and such.
    {ale_angry == 1: 
    (Mr. Ale doesn't seem interested in continuing the conversation.)
    }
    +   {ale_angry == 0}[Did the deaths affect them?]
        Mr. Ale: The missus not so much, a hard lady that one is.
        Mr. Ale: My son on the other hand... he wouldn't speak for a week after finding little Maria. To this day he isn't quite the same.
        ~brut_daughter_discoverer = 1
    +   +   [Was he involved?] 
            Mr. Ale: Are you insane?! Junior wouldn't hurt a fly if it was about to suck his blood!
            (The question seems to have angered him)
            ~ale_angry = 1
    -   -   -   ->Hub
    +   +   [How was she found?]
            Mr. Ale: I don't feel comfortable answering that question, Father. Her father is still alive, if anyone should give you details it should be him...
    +   +   +   [I have another question.]
                Mr. Ale: Sure, I'd be happy to help.
    -   -   -   ->Hub
    +   ->Hub

==Information==
Mr. Ale: I have a believable and an incredible story. Which one would you like to hear?
    +   [The factual one.]->Realistic_Story
    +   [The unrealistic one.]->Unrealistic_Story

=Realistic_Story
Mr. Ale: The night Father Wright died, he had gathered all the women and children in the church and locked them there overnight, probably to see if someone still died that night. 
    +   [Well, someone did.]
    Mr. Ale: Right, which is how we know that the creature is disguised as a man, because all the women and children were accounted for when he died, but none of the men. 
    Mr. Ale: Anyway, that's not the story, but rather that I saw someone waiting next to the church cemetery that night. Couldn't tell who.
    ~church_sighting = 1
    Mr. Ale: Not an exciting story, but I hope it helps.
    +   +   [What about the other story?] ->Unrealistic_Story
    +   +   [Let me ask you something else.]
            Mr. Ale: Sure.
    -   -   ->Hub
    

=Unrealistic_Story
Mr. Ale: You know that doctor in the market? They say there's no man under those clothes. 
Mr. Ale: That if you look under them, you will see nothing between the boots and the rest of the body. No legs at all.
~doctor_rumors = 1
+   [That seems like a nasty rumor.]
        Mr. Ale: Perhaps. But every often I do hear strange sounds coming out of the old house he moved into.   
        Mr. Ale: Phillip also died the same week the doctor moved in, so it's not just baseless paranoia.
+   +   [What about the other story?] ->Realistic_Story
+   +   [Let me ask you something else.]
        Mr. Ale: Sure.
-   -   ->Hub


==Leave==
Mr. Ale: Good luck.
.
->END