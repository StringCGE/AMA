# Use the official MariaDB image as the base image
FROM mariadb

# Set environment variables
ENV MYSQL_ROOT_PASSWORD=root
ENV MYSQL_DATABASE=AMA
ENV MYSQL_USER=ama
ENV MYSQL_PASSWORD=ama

# Copy any initialization scripts
COPY init.sql /docker-entrypoint-initdb.d/

# Expose port 3306
EXPOSE 3306