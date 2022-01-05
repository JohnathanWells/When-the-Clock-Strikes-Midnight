VAR church_letter = 0
VAR doctor_rumors = 0
VAR doctor_wife = 0
VAR doctor_gender = 0
VAR doctor_research = 0
VAR wright_plan = 0
VAR phillip_remains_found = 0
VAR tosh_skull = 0
VAR ale_night_tosh = 0
VAR smith_angry = 0
VAR _temp = 0
VAR brut_angry = 0
VAR town_anger = 0
->Intro

==Intro==
The Doctor: Father! Good seeing you today! What do you need?
->Hub

==Hub==
+[(Leave) May God be with you.]->Leave
+[You are not from around here.]->Past
+{wright_plan}[Where were you during the last full moon?]->Wright_Death
+{doctor_rumors}[What do you think of the rumors?]->Rumors
*{church_letter > 0}[Do you recognize this letter?]->Letter
+[What can you tell me about the deaths?]->Opinion
+{doctor_wife}[Where is your wife?]->Wife

==Past==
The Doctor: Indeed, I am not! I just moved here about six months ago. 
->Past_Questions
=Past_Questions
*[What made you move here?]
    The Doctor: A distant relative of mine left a house here after his untimely death, and I needed a place to perform research. This seemed like a perfect place for that.
    The Doctor: I don't really have anyone waiting for me back home, all the children moved away, so it's not any more lonely here than it used to be there.
    ~doctor_wife = 1
    ->Past_Questions
+{doctor_wife}[What happened to you wife?] ->Wife
+[Did you move before or after Phillip's death?] ->Past_Phillip
+[Why the outfit?]->Past_Outfit
+[I have other questions.]
    The Doctor: Of course! Go right ahead.
    ->Hub
    
=Past_Phillip
The Doctor: A couple of days before, actually. Of course that didn't look good with the locals, but I was attending the innkeeper's son when it happened.
The Doctor: They were so frustrated at my allibi, they didn't stop to ask if everyone else had one.
+   [You're saying that...]->Opinion
+   [So you were not involved?]
    The Doctor: Father, would I admit to such a heinous crime, even if I had committed it?
    ->Past_Questions

=Past_Outfit
The Doctor: It protects me from miasma, and conveniently hides my face.
+   [Why do you hide your face?]
    The Doctor: People are more likely to let you treat them when they don't see the scarring on your face.
    ->Past_Questions
+   [Why do you need to protect yourself from miasma?]
    The Doctor: You never know where illness may be hiding!
    The Doctor: And with all the corpses piling up, and now our dear gravedigger digging some of them up, we might have it at our doorstep sooner than later.
+   +   [Wait, what about Tosh?]
        The Doctor: Check his cabin, I saw him take it there.
        ->Past_Questions
+   [Where did you get it?]
    The Doctor: From my father. He died of a lung disease and left the uniform to me. Didn't see a use for it until last year, really.
    ->Past_Questions

==Rumors==
The Doctor: Sorry Father, you will have to be more specific.
+   [(Retell rumor about empty uniform).]
    The Doctor: Oh, it's just rumors. These people fear me, so they make things up about me.
    (The question has made the doctor nervous)
    ->Hub
+   [Sounds from house.]
    The Doctor: That's just my equipment. Nothing you haven't seen where you are from, but it frightens those in town.
    ->Hub

==Letter==
The Doctor: Hmm I can't say I do. Why do you ask?
+   [Not a lot of literate men in town]
    The Doctor: Ah! You're better asking Mr. Ale, Mr. Smith, or Gregory then.
    The Doctor: I was indeed married but live on my own now. Father Wright and Mr. Barber also knew how to read and write, but I doubt you will be able to get anything out of them now. 
    ->Letter_2
=Letter_2
+   +   {church_letter > 1}[Greg cannot read.]
        The Doctor: Oh, is that what he says? Uhh... Then forget I said anything!
        ~church_letter = 5
        ->Hub
-   +    ->Hub
->Hub

==Opinion==
The Doctor: Everyone in this town has secrets, Reverend. If you don't know that yet, you will by the end of the night.
The Doctor: How many people did the demon kill? All of them? Some of them? None of them? I wonder...
+   [You don't believe the demon exists?]
    The Doctor: I never said that. Everyone has the same feeling, the same sensation, something is wrong in this woods. But is maiming truly unique to the supernatural?
    The Doctor: Maybe you would be sending an innocent to the noose by chasing this demon. You should give it some thought.
+   +   [Maybe you are the demon.]
        The Doctor: Ha ha ha! I certainly could be! 
        {town_anger > 2} The Doctor: But I wonder if it would even matter now, with all these mortals plotting behind your back.
        (The Doctor seems amused.)
+   +   +   [What should I do?]
            ->Opinion_2
+   +   [What should I do?]
        ->Opinion_2
+   {tosh_skull and phillip_remains_found}[The demon is real. I have seen it.]
    The Doctor: Really? Could you see anyone else as well? I wonder if there's a connection if that's the case...
    ->Hub
    
=Opinion_2
The Doctor: That I cannot say! I doubt you will get clear answers in the short time you have left. Perhaps you should start by looking at those trying waste it. 
The Doctor: When the clock strikes midnight you will still have to make a decision. Be that what it might be. 
->Hub

==Wife==
The Doctor: My wife...? Oh... She's dead. I'm not as young behind this mask as I might sound he he.
->Hub

==Wright_Death==
The Doctor: Since Father Wright locked all the women and children in the chapel, I just spent the night here, cleaning my instruments.
->Hub

==Leave==
The Doctor: And with you too!
.
~town_anger = 0
{tosh_skull:
~town_anger++
}
{smith_angry:
~town_anger++
}
{brut_angry:
~town_anger++
}
{church_letter > 1:
~town_anger++
}
->END

