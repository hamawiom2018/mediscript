namespace medisoft.application.models;

public class GoogleCredentials
{
    /*"type": "service_account",
    "project_id": "medisoft-hackathon",
    "private_key_id": "c7c31740988e6b6705bff02296f39c1c41420aa3",
    "private_key": "-----BEGIN PRIVATE KEY-----\nMIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQCTCJs5aL+g2Lih\ngTF8Q8LcJli9+ARHiJM+5taJYWwO0F4e5oqqXdJau+l2d0WZDhhUwUqrnmjJ9ShB\np65As2QcNvYz5jUZhUuybz7VCBLqD15yDuxrzVQDa3cVxyFGAhCIyNeg4X7SqLXb\nFYYOh+0lGczNDc3HG0kzLU6lTOIX+9l17pBmBFiPJ9DrAArorsgc9hOkcnWPvIHt\nKpd2v1GACIDLpuAXqCzUY9Lg6SeGZAn8N27SO5z6wb7wQXszu8vtsJyWSdKAbzW7\nkNxw0C0DWaglOqxDbYeafTTFW5wq8l96K/q45KKFGnsNLrDZ0V5VN3xtdnQcZ2xQ\niGcbYmoZAgMBAAECggEANqHJA1DPexVrrN7TI0gOPDynVpa0CFxP0dx1tIAVZX+4\nqSSiO2E3Cu2tdo4ktxUMp1lWxGPMrdXAynxie7nsJauqWWhdLIlhsgAxyXgBhySE\nxD6VTAzz/X1NtzLRQzD7McfmjumadO2o/KmHsRiCXfmzJjHN1wBld3WLNlJV4/Do\nwvi0s4z+aW3J4dbnyVe1VfZl+68wg83gGnpF4Rp6zAGnZgwz7XvykapDoBHsyq80\nvM++ff8NHlAwhCmW6YMt7yP58gIYHyzh3y3FeMQun0TQJ4GpkPceCf7aCV+urV1+\n+Aoyi3H8l0d3U3ZCSeYjXC9sc/MXPA5EK8WdrOEATQKBgQDPS7wxylq7lnoi+B2A\nZJZXsQsr3dtnpEQ9qzT3XFUi5mCzSng0eM/mX33OL0Crn6ASlD8biB/4mC8DHrEH\nQYfd04VtBnv2jkPu6kTMAN8gVZuW2b2mQeCsYqh2EMmPKAdkWtH4iO/LhOf5rpjs\nbbeLTapKPmcD9sfXbxNkVHAXPwKBgQC1lERkYzC8bp7n04byK7VLk8Zc8Pnvz5Xf\nOY5COAlRLA24oQ0Xp40DQGt3WtYyEsXH3dX0l4T1lT4AWT4q5Ap+dlNq9bn3pQkm\nteIZApm0QqSPDAjKukamqa/i5iGgC2ZmKMpams3Y2SbXFP+9dgf1zYXEZ29zWhPa\nHkwsiizApwKBgH78gx3xOyHdLZbMba4gcGTpxNEriGN2IoOwpLK/cjv96tEKVpa2\nR411g+jR04kPMQ0QmZQxEHzGJU6A96tdPnDqSbsfFMNWJVFvW5OpGQaCytxfKKl3\ng722dkJVSFQVDmowpJ3erR78nOq8RVvYXm7MtfvjPFIWVBeqKLP2cfAbAoGAQetB\nqPAZkU7XgXHZW7Fib72GFdel5NmHnzJV4tRVDZLgqFZPWncJSlTorrvbZvJJuvVd\n5x3atw0nJRlA6HFBHgf24K20haL0X4lIO6wmALrw4r2Ls41MeNTBda32JxP8aLoG\nPD5W3JJ49zw4W5+t5B5ooZSrcUUST+0P2luPQ6ECgYAOtt1deveJXGeuABdtFfNA\nvleoh5+V7Lr47i02BluOIWFrzfu03aUyYVEXYu/KLA0L9aieeLJjrMBHtDJx83RW\nN3+CpFF1nq88nqJJuGb2bUasFgAJXOBBeFoQFNYf1Con1PGtP6CtsG0LKXr5xXPV\nTJU46mo2XTJvz2xSRU0Dvw==\n-----END PRIVATE KEY-----\n",
    "client_email": "api-hackathon@medisoft-hackathon.iam.gserviceaccount.com",
    "client_id": "107249872663069759455",
    "auth_uri": "https://accounts.google.com/o/oauth2/auth",
    "token_uri": "https://oauth2.googleapis.com/token",
    "auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
    "client_x509_cert_url": "https://www.googleapis.com/robot/v1/metadata/x509/api-hackathon%40medisoft-hackathon.iam.gserviceaccount.com",
    "universe_domain": "googleapis.com"*/
    public string type { get; set; }
    public string project_id { get; set; }
    public string private_key_id { get; set; }
    public string private_key { get; set; }
    public string client_email { get; set; }
    public string client_id { get; set; }
    public string auth_uri { get; set; }
    public string token_uri { get; set; }
    public string auth_provider_x509_cert_url { get; set; }
    public string client_x509_cert_url { get; set; }
    public string universe_domain { get; set; }
}