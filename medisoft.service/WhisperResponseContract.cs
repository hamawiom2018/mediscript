namespace medisoft.service
{
    public class WhisperResponseContract
    {
       /*
"{\"text\":\" They have a track of\",\"language\":\"en\",\"segments\":[{\"start\":0.22,\"end\":4.14,\"text\":\" They have a track of\",\"whole_word_timestamps\":[{\"word\":\" They\",\"start\":0.22,\"end\":0.84,\"probability\":0.0001225358573719859,\"timestamp\":0.84},{\"word\":\" have\",\"start\":0.84,\"end\":3.28,\"probability\":0.9691488146781921,\"timestamp\":3.28},{\"word\":\" a\",\"start\":3.3,\"end\":3.64,\"probability\":0.18204577267169952,\"timestamp\":3.64},{\"word\":\" track\",\"start\":3.68,\"end\":3.94,\"probability\":0.0032102346885949373,\"timestamp\":3.94},{\"word\":\" of\",\"start\":3.94,\"end\":4.14,\"probability\":0.5028798580169678,\"timestamp\":4.14}]}]}"
       */
        public string text { get; set; }
        public string language { get; set; }
        public Segment[] segments { get; set; }
    }
    public class Segment
    {
        public double start { get; set; }
        public double end { get; set; }
        public string text { get; set; }
        public Whole_Word_Timestamp[] whole_word_timestamps { get; set; }
    }

    public class Whole_Word_Timestamp
    {
        public string word { get; set; }
        public double start { get; set; }
        public double end { get; set; }
        public double probability { get; set; }
        public double timestamp { get; set; }
    }
}