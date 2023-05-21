export interface AudioTranscript {
    audio:string;
    transcript:string | undefined;
    isUploading?:boolean;
}
export var audioTranscriptsVar:AudioTranscript[]=[
    {audio:'assets/At the Doctors - English Conversation (online-audio-converter (mp3cut.net).mp3',
    transcript:"Good morning . What seems to be the problem ?Um-hum .  Well , I've been having really bad pains . Now , my chest area I've been struggling to get any sleep or go to work because of the pain I am going to press on your stomach . Tell me where it hurts . "+
    "Yes . That's where it hits mostOkay . So , it seems that you have abdominal painWhat's that ? "+
    "Abdomen , we first to your stomach . So , you have stomach pains "+
    "How long have you had this painful ?  About two weeks now .  Are you having any problems with your bowel movements "+
    "Sorry . What do you mean by that ? Are you able to go to the toilet without any problems ? No . I'm actually really struggling to go to the toilet . It's very pain",
isUploading:false}];

export interface TranscriptRequestContract {
    content: string;
}
