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
VAR town_anger = 3
VAR ale_angry = 0
VAR tosh_angry = 0
VAR allibi = 0
VAR doctor_door = 0

->Intro

==Intro==
The Doctor: Reverend! Good seeing you tonight! What do you need?
->Hub

==Hub==
+[(Leave) May God be with you.]->Leave
+[You are not from around here.]->Past
+{wright_plan}[Where were you during the last full moon?]->Wright_Death
+{doctor_rumors}[What do you think of the rumors?]
    The Doctor: Sorry Father, you will have to be more specific.
    ->Rumors
*{church_letter > 0}[Do you recognize this letter?]->Letter
*{doctor_door}[Why do I smell blood in your house?]->Blood
//+[Have you seen anything suspicious lately?]->Opinion

==Blood==
The Doctor: I am a doctor, Reverend. I would expect that to be enough justification to have blood in my house.
->Hub

==Past==
The Doctor: Indeed, I am not! I just moved to town about six months ago. 
->Past_Questions
==Past_Questions==
*[What made you move?]
    The Doctor: A distant relative of mine left a house here after his untimely death, and I needed a place to perform research. This seemed like a perfect place for that.
    The Doctor: I don't really have anyone waiting for me back home anyway. All the children moved away, so I'm not any more lonely.
    ~doctor_wife = 1
    ->Past_Questions
+{doctor_wife}[What happened to you wife?] ->Wife
+[Were you here before Phillip's death?] ->Past_Phillip
+[Why the outfit?]->Past_Outfit
+[I have other questions.]
    The Doctor: Of course! Go right ahead.
    ->Hub
    
==Past_Phillip==
The Doctor: I moved couple of days before, actually. Of course that didn't look good with the locals, but I was with the innkeeper and his son when it happened.
The Doctor: Everyone was so frustrated by my allibi, they didn't stop to ask if everyone else had one.
~allibi = 1
+   [You suspect the others?]->Opinion
+   [So you were not involved?]
    The Doctor: Father, would I admit to such a heinous crime, even if I had committed it?
    ->Past_Questions
+   [About your past...]
    The Doctor: What do you want to know?
    ->Past_Questions

==Past_Outfit==
The Doctor: It protects me from miasma, and conveniently hides my face.
->Past_Outfit_Questions
=Past_Outfit_Questions
+   [Why do you hide your face?]
    The Doctor: People are more likely to let you treat them when they don't see the scarring on your face hehe.
    ->Past_Outfit_Questions
+   [Why do you need to protect yourself from miasma?]
    The Doctor: You never know where illness may be hiding!
    The Doctor: And with all the corpses piling up, and now our dear gravedigger digging some of them up, we might have it at our doorstep sooner than later.
+   +   [Wait, what about Tosh?]
        The Doctor: Check his cabin, I saw him take it there.
        ->Past_Outfit_Questions
+   [Where did you get it?]
    The Doctor: From my father. He died of a lung disease and left the uniform to me. Didn't see a use for it until last year, really.
    ->Past_Outfit_Questions
+   [I have more questions.]
    The Doctor: Go ahead!
    ->Past_Questions

==Rumors==
+   [(Retell rumor about empty uniform).]
    The Doctor: Oh, it's just rumors. These people fear me, so they make things up about me hehe.
    ->Rumors
+   [Sounds from house.]
    The Doctor: That's just my equipment. Nothing you haven't seen where you are from, but it frightens those in town.
    ->Rumors
+   [Nevermind.]
    The Doctor: Huh, very well. How can I help you then?
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

==Deaths==
The Doctor: What do you want to know?
+   [The state of the bodies.]->Bodies
+   [Suspects.]->Opinion
+   [Nevermind.]
    The Doctor: Very well. How else can I help you?
    ->Hub

==Bodies==
The Doctor: Everyone was dismembered and found near the town.
The Doctor: Aside from that it's a little inconsistent. Some had marks of teeth or claws and most were missing a limb or two.
    ->Deaths

==Opinion==
The Doctor: Everyone in this town has secrets, Reverend. If you don't know that yet, you will by the end of the night.
The Doctor: How many people did the demon kill? All of them? Some of them? None of them? I wonder...
+   [You don't believe the demon exists?]
    The Doctor: I never said that. Everyone has the same gut feeling, the same sensation that something is wrong in these woods... 
    The Doctor: But is maiming truly unique to the supernatural? Maybe you would only be sending an innocent to the noose by chasing this demon. 
+   +   [Maybe you are the demon.]
        The Doctor: Ha ha ha! I certainly could be! 
        {town_anger > 2: The Doctor: But I wonder if it would even matter now, with so many already plotting behind your back.}
        (The Doctor seems amused.)
+   +   +   [What should I do?]
            ->Opinion_2
+   +   [What should I do?]
        ->Opinion_2
+   {tosh_skull and phillip_remains_found}[The demon is real. I have seen it.]
    The Doctor: Really? Was there anyone around when you saw it? I wonder if there's a connection if that's the case...
    ->Past_Questions
    
=Opinion_2
The Doctor: That I cannot say! I doubt you will get many clear answers in the short time you have left, so perhaps you should start by looking at those trying to waste it. 
The Doctor: When the clock strikes midnight you will still have to make a decision. Be that what it might be. 
->Past_Questions

==Wife==
The Doctor: My wife...? Oh... She's dead. I'm not as young behind this mask as I might sound hehe.
->Past_Questions

==Wright_Death==
The Doctor: Since Father Wright locked all the women and children in the chapel, I just spent the night inside my house, cleaning my instruments.
->Hub

==Leave==

{   town_anger >= 3:
        The Doctor: Be careful out there, Reverend. Turn enough stones and you might find yourself bitten by a snake. 
-   else: 
        The Doctor: And with you too!
}
.
~town_anger = 0
{tosh_angry:
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
{ale_angry:
~town_anger++
}
->END

