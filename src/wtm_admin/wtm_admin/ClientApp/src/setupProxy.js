
const proxy = require('http-proxy-middleware');
const mock = require('./mock');

module.exports = (app) => {
    app.use(proxy('/api', {
        target: 'http://localhost:8299/',
        changeOrigin: true,
        logLevel: "debug"
    }));
    app.use(proxy('/swagger', {
        target: 'http://localhost:8299/',
        changeOrigin: true,
        logLevel: "debug"
    }));
    mock(app);
};
