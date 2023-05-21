import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TranscriptRequestContract } from 'src/models/audio.transcript.model';

@Injectable({
  providedIn: 'root'
})
export class TranscriptService {

  constructor(private httpClient: HttpClient) { }
  uploadTranscript(audioContent:TranscriptRequestContract): Observable<TranscriptRequestContract> {
    return this.httpClient.post<TranscriptRequestContract>('api/Transcript/upload', audioContent);
  }
}
