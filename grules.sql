/*
 Navicat Premium Data Transfer

 Source Server         : Local
 Source Server Type    : MySQL
 Source Server Version : 100408
 Source Host           : localhost:33060
 Source Schema         : grules

 Target Server Type    : MySQL
 Target Server Version : 100408
 File Encoding         : 65001

 Date: 20/11/2019 00:28:44
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for alunos
-- ----------------------------
DROP TABLE IF EXISTS `alunos`;
CREATE TABLE `alunos`  (
  `IdAluno` int(11) NOT NULL,
  `IdGrupo` int(11) NULL DEFAULT NULL,
  `Nome` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Sobrenome` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CPF` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Matricula` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Celular` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Email` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Endereco` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Numero` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Complemento` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Bairro` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Estado` varchar(2) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Cidade` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `CEP` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Observacoes` text CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  PRIMARY KEY (`IdAluno`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for alunos_grupo
-- ----------------------------
DROP TABLE IF EXISTS `alunos_grupo`;
CREATE TABLE `alunos_grupo`  (
  `IdAlunoGrupo` int(11) NOT NULL,
  `IdAluno` int(11) NULL DEFAULT NULL,
  `IdGrupo` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`IdAlunoGrupo`) USING BTREE,
  INDEX `fk_alunos_grupo_aluno_id`(`IdAluno`) USING BTREE,
  INDEX `fk_alunos_grupo_grupo_is`(`IdGrupo`) USING BTREE,
  CONSTRAINT `fk_alunos_grupo_aluno_id` FOREIGN KEY (`IdAluno`) REFERENCES `alunos` (`IdAluno`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_alunos_grupo_grupo_is` FOREIGN KEY (`IdGrupo`) REFERENCES `grupos` (`IdGrupo`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for eventos
-- ----------------------------
DROP TABLE IF EXISTS `eventos`;
CREATE TABLE `eventos`  (
  `IdEvento` int(11) NOT NULL,
  `Descricao` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DataInicio` datetime(0) NOT NULL,
  `DataTermino` datetime(0) NOT NULL,
  `DataInclusao` datetime(0) NOT NULL,
  PRIMARY KEY (`IdEvento`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for grupos
-- ----------------------------
DROP TABLE IF EXISTS `grupos`;
CREATE TABLE `grupos`  (
  `IdGrupo` int(11) NOT NULL,
  `Titulo` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `Descricao` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
  `IdEvento` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`IdGrupo`) USING BTREE,
  INDEX `fk_grupos_evento_id`(`IdEvento`) USING BTREE,
  CONSTRAINT `fk_grupos_evento_id` FOREIGN KEY (`IdEvento`) REFERENCES `eventos` (`IdEvento`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for perfis
-- ----------------------------
DROP TABLE IF EXISTS `perfis`;
CREATE TABLE `perfis`  (
  `perfil_id` int(11) NOT NULL,
  `nome` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `criado_em` datetime(0) NOT NULL DEFAULT current_timestamp(0),
  `atualizado_em` datetime(0) NOT NULL DEFAULT current_timestamp(0) ON UPDATE CURRENT_TIMESTAMP(0),
  `apagado_em` datetime(0) NULL DEFAULT NULL,
  `criado_por` int(11) NULL DEFAULT NULL,
  `atualizado_por` int(11) NULL DEFAULT NULL,
  `apagado_por` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`perfil_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for permissoes
-- ----------------------------
DROP TABLE IF EXISTS `permissoes`;
CREATE TABLE `permissoes`  (
  `permissao_id` int(11) NOT NULL AUTO_INCREMENT,
  `perfil_id` int(11) NULL DEFAULT NULL,
  `tela_id` int(11) NULL DEFAULT NULL,
  `permissao` char(1) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'N',
  PRIMARY KEY (`permissao_id`) USING BTREE,
  INDEX `fk_permissoes_perfil_id`(`perfil_id`) USING BTREE,
  INDEX `fk_permissoes_tela_id`(`tela_id`) USING BTREE,
  CONSTRAINT `fk_permissoes_perfil_id` FOREIGN KEY (`perfil_id`) REFERENCES `perfis` (`perfil_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_permissoes_tela_id` FOREIGN KEY (`tela_id`) REFERENCES `telas` (`tela_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for presenca
-- ----------------------------
DROP TABLE IF EXISTS `presenca`;
CREATE TABLE `presenca`  (
  `IdPresenca` int(11) NULL DEFAULT NULL,
  `IdAluno` int(11) NULL DEFAULT NULL,
  `IdEvento` int(11) NULL DEFAULT NULL,
  INDEX `fk_presenca_aluno_id`(`IdAluno`) USING BTREE,
  INDEX `fk_presenca_evento_id`(`IdEvento`) USING BTREE,
  CONSTRAINT `fk_presenca_aluno_id` FOREIGN KEY (`IdAluno`) REFERENCES `alunos` (`IdAluno`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_presenca_evento_id` FOREIGN KEY (`IdEvento`) REFERENCES `eventos` (`IdEvento`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for telas
-- ----------------------------
DROP TABLE IF EXISTS `telas`;
CREATE TABLE `telas`  (
  `tela_id` int(11) NOT NULL AUTO_INCREMENT,
  `tela` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `titulo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`tela_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for usuarios
-- ----------------------------
DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE `usuarios`  (
  `usuario_id` int(11) NOT NULL,
  `nome` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `sobrenome` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `email` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `senha` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `perfil_id` int(11) NULL DEFAULT NULL,
  `criado_em` datetime(0) NOT NULL DEFAULT current_timestamp(0),
  `atualizado_em` datetime(0) NOT NULL DEFAULT current_timestamp(0) ON UPDATE CURRENT_TIMESTAMP(0),
  `apagado_em` datetime(0) NULL DEFAULT NULL,
  `criado_por` int(11) NULL DEFAULT NULL,
  `atualizado_por` int(11) NULL DEFAULT NULL,
  `apagado_por` int(11) NULL DEFAULT NULL,
  `busca` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`usuario_id`) USING BTREE,
  INDEX `fk_usuarios_perfil_id`(`perfil_id`) USING BTREE,
  CONSTRAINT `fk_usuarios_perfil_id` FOREIGN KEY (`perfil_id`) REFERENCES `perfis` (`perfil_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
