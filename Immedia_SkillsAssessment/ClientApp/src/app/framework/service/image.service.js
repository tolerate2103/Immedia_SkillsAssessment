"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ImageService = void 0;
var ImageService = /** @class */ (function () {
    function ImageService(http) {
        this.http = http;
    }
    ImageService.prototype.getImage = function (imageUrl) {
        return this.http.get(imageUrl, { responseType: 'blob' });
    };
    return ImageService;
}());
exports.ImageService = ImageService;
//# sourceMappingURL=image.service.js.map