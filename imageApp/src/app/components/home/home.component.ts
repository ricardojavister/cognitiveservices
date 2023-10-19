import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Tag } from 'src/app/models/tag';
import { ImageService } from 'src/app/services/image.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  @Input({ required: false }) url!: string;
  imageURL!: string;
  form!: any;
  tags!: Tag[];

  constructor(public fb: FormBuilder, public imageService: ImageService) {}
  ngOnInit(): void {
    // Reactive Form

    this.form = this.fb.group({
      url: [null],
    });
  }
  showPreview(event: any) {
    this.imageURL = this.form.value.url;
  }

  submit() {
    this.imageService.GetAnalysis(this.imageURL).subscribe(x=>{
      this.tags = x;
    });
  }
}
