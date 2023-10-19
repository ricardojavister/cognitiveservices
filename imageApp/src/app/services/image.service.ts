import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tag } from '../models/tag';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImageService {
  api = 'api/ImageAnalyzer';
  constructor(private http: HttpClient) {}
  public GetAnalysis(url: string): Observable<Tag[]>{
    return this.http.get<Tag[]>(
      `${environment.apiEndpoint}${this.api}/url?url=${url}`
    );
  }
}
