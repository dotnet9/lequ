# Lequ.CO

## 1. docker部署

### 1.1 docker build

1. vs F5 运行项目(Docker)
2. 推送镜像

```
$ docker login --username=沙漠之狐546477 registry.cn-hangzhou.aliyuncs.com
$ docker tag [ImageId] registry.cn-hangzhou.aliyuncs.com/lequ_co/lequ_co:[镜像版本号]
$ docker push registry.cn-hangzhou.aliyuncs.com/lequ_co/lequ_co:[镜像版本号]
```

3. 服务器安装Docker

参考：[【One by one系列】一步步学习docker（一）——初窥docker原理](http://www.randyfield.cn/post/2020-03-26-docker1/)

4. 拉取镜像、运行

指定端口运行镜像

```
docker run -d -p 宿主机port:docker端口 IMAGE_ID
```

- -d： 守护进程方式运行
- -p： 指定宿主机和docker端口映射

### 2 感谢

- 博客参考视频，YouTube大神[穆拉特·尤塞达格](https://www.youtube.com/user/YazilimHerYerde)的[Asp.Net Core 5.0 项目营](https://www.youtube.com/playlist?list=PLKnjBHu2xXNNkinaVhPqPZG0ubaLN63ci)系列
- 前台前端模板[CoreBlogTema]()
- 后台前端模板[PurpleAdmin]()