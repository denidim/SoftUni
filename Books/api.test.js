//setting up the dependencies
const chai = require('chai');
const chaiHttp = require('chai-http');
const server = require('./server');
const expect = chai.expect;

chai.use(chaiHttp);

describe('Books API', () => {
    it('should POST a book', (done) => {
        const book = { id: '1', title: 'Test Book', author: 'Test Author' };
        chai.request(server)
            .post('/books')
            .send(book)
            .end((err, res) => {
                if (err) {
                    return done(err)
                }
                expect(res.statusCode, "Status code").to.be.equal(201);
                expect(res.body, "ResponseBody").to.be.a('object');
                expect(res.body, "ResponseBody").to.have.property('id');
                expect(res.body.id, "BookId property").to.be.equal(book.id);
                expect(res.body.title, "BookTitle property").to.be.equal(book.title);
                expect(res.body.author, "BookAuthor property").to.be.equal(book.author);
                console.log("response: ", res.body);
                done();
            });
    })

    it('should GET all books', (done) => {
        chai.request(server)
            .get('/books')
            .end((err, res) => {
                if (err) {
                    return done(err)
                }
                expect(res.statusCode, "Status code").to.be.equal(200);
                expect(res.body[0].id, "BookId property").to.be.equal('1');
                expect(res.body).to.be.a('array');
                console.log("response: ", res.body);
                done();
            });
    })

    it('should GET a single book', (done) => {
        const bookId = 1;
        chai.request(server)
            .get(`/books/${bookId}`)
            .end((err, res) => {
                if (err) {
                    return done(err)
                }
                expect(res).to.have.status(200);
                expect(res.body).to.be.a('object');
                expect(res.body).to.have.property('id');
                expect(res.body).to.have.property('title');
                expect(res.body).to.have.property('author');
                console.log("response: ", res.body);
                done();
            });
    })

    it('should PUT an existing book', (done) => {
        const bookId = 1;
        const updateBook = { id: bookId, title: 'Updated Test Book', author: 'Updated Test Author' };
        chai.request(server)
            .put(`/books/${bookId}`)
            .send(updateBook)
            .end((err, res) => {
                if (err) {
                    return done(err)
                }
                expect(res.statusCode, "Status code").to.be.equal(200);
                expect(res.body, "ResponseBody").to.be.a('object');
                expect(res.body, "ResponseBody").to.have.property('id');
                expect(res.body.id, "BookId property").to.be.equal(updateBook.id);
                expect(res.body.title, "BookTitle property").to.be.equal(updateBook.title);
                expect(res.body.author, "BookAuthor property").to.be.equal(updateBook.author);
                console.log("response: ", res.body);
                done();
            });
    })

    it('should return 404 when trying to GET, PUT or DELETE a non-existing book', (done) => {
        const nonExistingId = 999;
        const nonExistingBook = { id: nonExistingId, title: 'NonExisting Test Book', author: 'NonExisting Test Author' };

        chai.request(server)
            .get(`/books/${nonExistingId}`)
            .end((err, res) => {
                if (err) {
                    return done(err)
                }
                expect(res.statusCode, "Status code").to.be.equal(404);
                console.log("response: ", res.body);
            });

            chai.request(server)
            .put(`/books/${nonExistingId}`)
            .send(nonExistingBook)
            .end((err, res) => {
                if (err) {
                    return done(err)
                }
                expect(res.statusCode, "Status code").to.be.equal(404);
                console.log("response: ", res.body);
            });

            chai.request(server)
            .delete(`/books/${nonExistingId}`)
            .end((err, res) => {
                if (err) {
                    return done(err)
                }
                expect(res.statusCode, "Status code").to.be.equal(404);
                console.log("response: ", res.body);
                done();
            });
    })
})